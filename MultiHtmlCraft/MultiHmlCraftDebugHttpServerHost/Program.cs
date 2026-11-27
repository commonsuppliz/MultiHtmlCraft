using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


const string MultiHmlCraftLocalHttpServerHostportNumber = "18080";
StopExistingServerInstances();


string projectRoot = FindProjectDirectory(AppContext.BaseDirectory);
string sourceDir = args.Length > 0
    ? Path.GetFullPath(args[0])
    : Path.Combine(projectRoot, "TestHtmlFiles");

string staticDir = args.Length > 1
    ? Path.GetFullPath(args[1])
    : Path.Combine(AppContext.BaseDirectory, "wwwroot");



SyncStaticDirectory(sourceDir, staticDir);
const string hostUrl = $"http://127.0.0.1:{MultiHmlCraftLocalHttpServerHostportNumber}";

const string prefix = hostUrl;
string listenerPrefix = hostUrl.EndsWith('/') ? hostUrl : hostUrl + "/";
using HttpListener listener = new HttpListener();
listener.Prefixes.Add(listenerPrefix);
listener.Start();

Console.WriteLine($"MultiHtmlCraftLocalHttpServer listening on {prefix}");
Console.WriteLine($"Source directory : {Path.GetFullPath(sourceDir)}");
Console.WriteLine($"Static directory : {Path.GetFullPath(staticDir)}");
Console.WriteLine("Press Ctrl+C to stop.");

using CancellationTokenSource cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

while (!cts.IsCancellationRequested)
{
    HttpListenerContext? ctx = null;
    try
    {
        ctx = await listener.GetContextAsync().WaitAsync(cts.Token);
        _ = Task.Run(() => HandleRequestAsync(ctx, staticDir, cts.Token), cts.Token);
    }
    catch (OperationCanceledException)
    {
        break;
    }
    catch (HttpListenerException) when (cts.IsCancellationRequested || !listener.IsListening)
    {
        break;
    }
    catch
    {
        try { ctx?.Response.Abort(); } catch { }
    }
}

try
{
    if (listener.IsListening)
    {
        listener.Stop();
    }
    listener.Close();
}
catch { }

static string FindProjectDirectory(string startDir)
{
    DirectoryInfo? current = new DirectoryInfo(Path.GetFullPath(startDir));
    while (current is not null)
    {
        if (current.GetFiles("*.csproj").Length > 0)
        {
            return current.FullName;
        }
        current = current.Parent;
    }
    return Path.GetFullPath(startDir);
}

static void SyncStaticDirectory(string sourceDir, string targetDir)
{
    string sourceFull = Path.GetFullPath(sourceDir);
    string targetFull = Path.GetFullPath(targetDir);

    if (!Directory.Exists(sourceFull))
    {
        if (Directory.Exists(targetFull))
        {
            DeleteMissingFilesAndEmptyDirs(
                sourceFull,
                targetFull,
                new HashSet<string>(StringComparer.OrdinalIgnoreCase));
        }
        return;
    }

    if (!Directory.Exists(targetFull))
    {
        Directory.CreateDirectory(targetFull);
    }

    HashSet<string> validRelativeFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    foreach (string srcFile in Directory.EnumerateFiles(sourceFull, "*", SearchOption.AllDirectories))
    {
        string relativePath = Path.GetRelativePath(sourceFull, srcFile);
        validRelativeFiles.Add(relativePath);

        string dstFile = Path.Combine(targetFull, relativePath);
        string? dstParent = Path.GetDirectoryName(dstFile);

        bool needsCopy = !File.Exists(dstFile);
        if (!needsCopy)
        {
            FileInfo srcInfo = new FileInfo(srcFile);
            FileInfo dstInfo = new FileInfo(dstFile);
            needsCopy = srcInfo.Length != dstInfo.Length
                        || srcInfo.LastWriteTimeUtc > dstInfo.LastWriteTimeUtc;
        }

        if (needsCopy)
        {
            if (!string.IsNullOrEmpty(dstParent) && !Directory.Exists(dstParent))
            {
                Directory.CreateDirectory(dstParent);
            }
            File.Copy(srcFile, dstFile, overwrite: true);
            Console.WriteLine($"[Sync] Copied: {relativePath}");
        }
    }

    DeleteMissingFilesAndEmptyDirs(sourceFull, targetFull, validRelativeFiles);
}

static void DeleteMissingFilesAndEmptyDirs(
    string sourceFull,
    string targetFull,
    HashSet<string> validRelativeFiles)
{
    if (!Directory.Exists(targetFull))
    {
        return;
    }

    foreach (string dstFile in Directory.EnumerateFiles(targetFull, "*", SearchOption.AllDirectories))
    {
        string relativePath = Path.GetRelativePath(targetFull, dstFile);
        if (!validRelativeFiles.Contains(relativePath))
        {
            File.Delete(dstFile);
            Console.WriteLine($"[Sync] Deleted: {relativePath}");
        }
    }

    List<string> subDirs = Directory.EnumerateDirectories(targetFull, "*", SearchOption.AllDirectories)
        .OrderByDescending(d => d.Length)
        .ToList();

    foreach (string subDir in subDirs)
    {
        string relativeDir = Path.GetRelativePath(targetFull, subDir);
        string correspondingSrcDir = Path.Combine(sourceFull, relativeDir);
        bool existsInSource = Directory.Exists(sourceFull) && Directory.Exists(correspondingSrcDir);

        if (!existsInSource && !Directory.EnumerateFileSystemEntries(subDir).Any())
        {
            Directory.Delete(subDir, recursive: false);
            Console.WriteLine($"[Sync] Removed empty dir: {relativeDir}");
        }
    }
}

static Dictionary<string, string> ParseQueryString(string? rawQuery)
{
    Dictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    if (string.IsNullOrEmpty(rawQuery))
    {
        return result;
    }

    string trimmed = rawQuery.StartsWith('?') ? rawQuery[1..] : rawQuery;
    string[] pairs = trimmed.Split('&', StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < pairs.Length; i++)
    {
        string pair = pairs[i];
        int eqIndex = pair.IndexOf('=');
        if (eqIndex < 0)
        {
            string keyOnly = Uri.UnescapeDataString(pair.Replace('+', ' '));
            result[keyOnly] = string.Empty;
        }
        else
        {
            string key = Uri.UnescapeDataString(pair[..eqIndex].Replace('+', ' '));
            string value = Uri.UnescapeDataString(pair[(eqIndex + 1)..].Replace('+', ' '));
            result[key] = value;
        }
    }

    return result;
}

static void LogRequestDetails(
    HttpListenerContext ctx,
    string method,
    string path,
    Dictionary<string, string> queryMap,
    string body)
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine($"[{DateTime.Now:HH:mm:ss.fff}] {method} {ctx.Request.Url?.PathAndQuery ?? path}");

    if (queryMap.Count > 0)
    {
        sb.AppendLine("  Query:");
        foreach (KeyValuePair<string, string> kv in queryMap)
        {
            sb.AppendLine($"    {kv.Key} = {kv.Value}");
        }
    }

    sb.AppendLine("  Headers:");
    foreach (string? key in ctx.Request.Headers.AllKeys)
    {
        if (!string.IsNullOrEmpty(key))
        {
            string val = ctx.Request.Headers[key] ?? string.Empty;
            sb.AppendLine($"    {key}: {val}");
        }
    }

    if (body.Length > 0)
    {
        string preview = body.Length > 2000 ? body[..2000] + "...(truncated)" : body;
        sb.AppendLine($"  Body ({body.Length} chars): {preview}");
    }

    Console.Write(sb.ToString());
}

static void ApplyCustomResponseHeadersAndStatus(
    HttpListenerContext ctx,
    Dictionary<string, string> queryMap,
    int defaultStatusCode = 200)
{
    int statusCode = defaultStatusCode;
    if (queryMap.TryGetValue("code", out string? codeStr)
        && int.TryParse(codeStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsedCode)
        && parsedCode >= 100 && parsedCode <= 599)
    {
        statusCode = parsedCode;
    }
    else if (queryMap.TryGetValue("status", out string? statusStr)
        && int.TryParse(statusStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsedStatus)
        && parsedStatus >= 100 && parsedStatus <= 599)
    {
        statusCode = parsedStatus;
    }

    ctx.Response.StatusCode = statusCode;

    // 単一ヘッダー指定: ?headerName=X-Custom&headerValue=123
    if (queryMap.TryGetValue("headerName", out string? headerName)
        && !string.IsNullOrWhiteSpace(headerName))
    {
        string headerValue = queryMap.TryGetValue("headerValue", out string? hv) ? hv : string.Empty;
        ctx.Response.Headers[headerName.Trim()] = headerValue;
    }

    // 複数ヘッダー指定: ?respHeader=X-A:val1,X-B:val2
    if (queryMap.TryGetValue("respHeader", out string? multiHeaders)
        && !string.IsNullOrWhiteSpace(multiHeaders))
    {
        string[] items = multiHeaders.Split(',', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < items.Length; i++)
        {
            int colon = items[i].IndexOf(':');
            if (colon > 0)
            {
                string name = items[i][..colon].Trim();
                string val = items[i][(colon + 1)..].Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    ctx.Response.Headers[name] = val;
                }
            }
        }
    }
}

static async Task ApplyDelayIfRequestedAsync(Dictionary<string, string> queryMap, CancellationToken ct)
{
    if (queryMap.TryGetValue("delayMs", out string? delayStr)
        && int.TryParse(delayStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out int delayMs)
        && delayMs > 0 && delayMs <= 60000)
    {
        await Task.Delay(delayMs, ct);
    }
}
static async Task HandleWebSocketAsync(
    HttpListenerContext ctx,
    string path,
    Dictionary<string, string> queryMap,
    CancellationToken ct)
{
    HttpListenerWebSocketContext? wsContext = null;
    try
    {
        string? subProtocol = queryMap.TryGetValue("protocol", out string? p) && !string.IsNullOrWhiteSpace(p)
            ? p.Trim()
            : null;

        wsContext = await ctx.AcceptWebSocketAsync(subProtocol);
        WebSocket socket = wsContext.WebSocket;

        Console.WriteLine($"[WS] Connected: {path} (subProtocol={socket.SubProtocol ?? "none"})");

        byte[] buffer = new byte[8192];
        using MemoryStream frameBuffer = new MemoryStream();

        while (!ct.IsCancellationRequested && socket.State == WebSocketState.Open)
        {
            frameBuffer.SetLength(0);
            WebSocketReceiveResult result;

            do
            {
                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), ct);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    Console.WriteLine($"[WS] Closing ({result.CloseStatus}): {result.CloseStatusDescription}");
                    await socket.CloseOutputAsync(
                        result.CloseStatus ?? WebSocketCloseStatus.NormalClosure,
                        result.CloseStatusDescription,
                        ct);
                    return;
                }

                if (result.Count > 0)
                {
                    frameBuffer.Write(buffer, 0, result.Count);
                }
            }
            while (!result.EndOfMessage);

            byte[] payload = frameBuffer.ToArray();

            if (result.MessageType == WebSocketMessageType.Text)
            {
                string text = Encoding.UTF8.GetString(payload);
                string preview = text.Length > 1000 ? text[..1000] + "...(truncated)" : text;
                Console.WriteLine($"[WS] RECV TEXT ({payload.Length} bytes): {preview}");

                // JSON 形式なら echo 情報付きで返し、それ以外はそのままエコー
                string replyText = BuildWebSocketEchoText(text);
                byte[] replyBytes = Encoding.UTF8.GetBytes(replyText);
                await socket.SendAsync(
                    new ArraySegment<byte>(replyBytes),
                    WebSocketMessageType.Text,
                    endOfMessage: true,
                    ct);
            }
            else if (result.MessageType == WebSocketMessageType.Binary)
            {
                Console.WriteLine($"[WS] RECV BINARY ({payload.Length} bytes)");
                await socket.SendAsync(
                    new ArraySegment<byte>(payload),
                    WebSocketMessageType.Binary,
                    endOfMessage: true,
                    ct);
            }
        }
    }
    catch (OperationCanceledException)
    {
        // シャットダウン時
    }
    catch (WebSocketException ex)
    {
        Console.WriteLine($"[WS] WebSocketException: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[WS] Error: {ex.Message}");
    }
    finally
    {
        try
        {
            if (wsContext?.WebSocket.State == WebSocketState.Open)
            {
                await wsContext.WebSocket.CloseAsync(
                    WebSocketCloseStatus.InternalServerError,
                    "Server closing connection",
                    CancellationToken.None);
            }
        }
        catch { }

        try { wsContext?.WebSocket.Dispose(); } catch { }
    }
}


static void StopExistingServerInstances()
{
    int currentPid = Environment.ProcessId;
    string currentProcessName = Process.GetCurrentProcess().ProcessName;

    foreach (Process proc in Process.GetProcessesByName(currentProcessName))
    {
        if (proc.Id == currentPid)
        {
            continue;
        }

        try
        {
            proc.Kill(entireProcessTree: true);

            proc.WaitForExit(3000);
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Existing MultiversalCraftHttpServerHost Process pid : {proc.Id} terminated in order to relase port :{MultiHmlCraftLocalHttpServerHostportNumber}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Process terminate error: {ex.Message}");
            
        }
        finally
        {
            proc.Dispose();
        }
    }
}

static string BuildWebSocketEchoText(string receivedText)
{
    try
    {
        using JsonDocument doc = JsonDocument.Parse(receivedText);
        return JsonSerializer.Serialize(new
        {
            type = "echo",
            received = doc.RootElement.Clone(),
            timestamp = DateTimeOffset.UtcNow
        });
    }
    catch (JsonException)
    {
        return receivedText;
    }
}

static async Task HandleRequestAsync(HttpListenerContext ctx, string rootDir, CancellationToken ct)
{
    try
    {

        string method = ctx.Request.HttpMethod.ToUpperInvariant();
        string rawPath = ctx.Request.Url?.AbsolutePath ?? "/";
        string path = rawPath.StartsWith('/') ? rawPath : "/" + rawPath;
        Dictionary<string, string> queryMap = ParseQueryString(ctx.Request.Url?.Query);

        string body = ctx.Request.HasEntityBody
            ? await new StreamReader(
                ctx.Request.InputStream,
                ctx.Request.ContentEncoding ?? Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true).ReadToEndAsync(ct)
            : string.Empty;
        if (ctx.Request.IsWebSocketRequest)
        {
            await HandleWebSocketAsync(ctx, path, queryMap, ct);
            return;
        }
    
        LogRequestDetails(ctx, method, path, queryMap, body);
        await ApplyDelayIfRequestedAsync(queryMap, ct);

        // 1. 任意ステータスコード・レスポンスヘッダー検証用エンドポイント
        if (path.Equals("/api/status", StringComparison.OrdinalIgnoreCase))
        {
            ApplyCustomResponseHeadersAndStatus(ctx, queryMap, defaultStatusCode: 200);
            Dictionary<string, string> receivedHeaders = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string? key in ctx.Request.Headers.AllKeys)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    receivedHeaders[key] = ctx.Request.Headers[key] ?? string.Empty;
                }
            }

            await WriteJsonAsync(
                ctx,
                new
                {
                    ok = ctx.Response.StatusCode >= 200 && ctx.Response.StatusCode < 300,
                    statusCode = ctx.Response.StatusCode,
                    method,
                    path,
                    query = queryMap,
                    receivedHeaders,
                    receivedBody = body,
                    timestamp = DateTimeOffset.UtcNow
                },
                ct);
            return;
        }

        // 2. fetch + async/await 検証用 API エンドポイント
        if (method == "GET" && path.Equals("/api/greeting", StringComparison.OrdinalIgnoreCase))
        {
            ApplyCustomResponseHeadersAndStatus(ctx, queryMap, defaultStatusCode: 200);
            await WriteJsonAsync(
                ctx,
                new
                {
                    ok = true,
                    message = "Hello from LocalDebugHttpServer",
                    query = queryMap,
                    timestamp = DateTimeOffset.UtcNow
                },
                ct);
            return;
        }

        if (method == "POST" && path.Equals("/api/echo", StringComparison.OrdinalIgnoreCase))
        {
            ApplyCustomResponseHeadersAndStatus(ctx, queryMap, defaultStatusCode: 200);
            string contentType = ctx.Request.ContentType ?? string.Empty;
            await WriteJsonAsync(
                ctx,
                new
                {
                    ok = true,
                    receivedContentType = contentType,
                    receivedBody = body,
                    query = queryMap,
                    timestamp = DateTimeOffset.UtcNow
                },
                ct);
            return;
        }

        // 3. 静的ファイル配信（HTML / CSS / JS / JSON / 画像等）
        if ((method == "GET" || method == "HEAD") && TryResolveFile(rootDir, path, out string? fullPath))
        {
            byte[] bytes = await File.ReadAllBytesAsync(fullPath!, ct);
            ApplyCustomResponseHeadersAndStatus(ctx, queryMap, defaultStatusCode: 200);
            ctx.Response.ContentType = GetContentType(fullPath!);
            ctx.Response.ContentLength64 = bytes.Length;
            if (method == "GET")
            {
                await ctx.Response.OutputStream.WriteAsync(bytes, ct);
            }
            ctx.Response.OutputStream.Close();
            return;
        }

        // 4. ディレクトリ一覧表示（index.html がないディレクトリ向け）
        if ((method == "GET" || method == "HEAD") && TryResolveDirectoryListing(rootDir, path, out string? targetDir))
        {
            string html = BuildDirectoryListingHtml(rootDir, targetDir!, path);
            byte[] bytes = Encoding.UTF8.GetBytes(html);
            ApplyCustomResponseHeadersAndStatus(ctx, queryMap, defaultStatusCode: 200);
            ctx.Response.ContentType = "text/html; charset=utf-8";
            ctx.Response.ContentLength64 = bytes.Length;
            if (method == "GET")
            {
                await ctx.Response.OutputStream.WriteAsync(bytes, ct);
            }
            ctx.Response.OutputStream.Close();
            return;
        }

        // 5. 404 Not Found
        byte[] notFound = Encoding.UTF8.GetBytes($"Not Found: {method} {path}");
        ApplyCustomResponseHeadersAndStatus(ctx, queryMap, defaultStatusCode: 404);
        ctx.Response.ContentType = "text/plain; charset=utf-8";
        ctx.Response.ContentLength64 = notFound.Length;
        await ctx.Response.OutputStream.WriteAsync(notFound, ct);
        ctx.Response.OutputStream.Close();
    }
    catch
    {
        try { ctx.Response.Abort(); } catch { }
    }
}

static async Task WriteJsonAsync(HttpListenerContext ctx, object payload, CancellationToken ct)
{
    string json = JsonSerializer.Serialize(payload);
    byte[] bytes = Encoding.UTF8.GetBytes(json);
    ctx.Response.ContentType = "application/json; charset=utf-8";
    ctx.Response.ContentLength64 = bytes.Length;
    await ctx.Response.OutputStream.WriteAsync(bytes, ct);
    ctx.Response.OutputStream.Close();
}

static bool TryResolveFile(string rootDir, string requestPath, out string? fullPath)
{
    fullPath = null;
    if (string.IsNullOrWhiteSpace(rootDir) || !Directory.Exists(rootDir))
    {
        return false;
    }

    string rootFull = Path.GetFullPath(rootDir);
    string rel = requestPath.TrimStart('/');
    if (string.IsNullOrEmpty(rel))
    {
        rel = "index.html";
    }

    string candidate = Path.GetFullPath(Path.Combine(rootFull, rel));
    string rootWithSep = rootFull.EndsWith(Path.DirectorySeparatorChar)
        ? rootFull
        : rootFull + Path.DirectorySeparatorChar;

    if (!candidate.StartsWith(rootWithSep, StringComparison.OrdinalIgnoreCase))
    {
        return false;
    }

    if (Directory.Exists(candidate))
    {
        candidate = Path.Combine(candidate, "index.html");
    }

    if (!File.Exists(candidate))
    {
        return false;
    }

    fullPath = candidate;
    return true;
}

static bool TryResolveDirectoryListing(string rootDir, string requestPath, out string? fullDirectoryPath)
{
    fullDirectoryPath = null;
    if (string.IsNullOrWhiteSpace(rootDir) || !Directory.Exists(rootDir))
    {
        return false;
    }

    string rootFull = Path.GetFullPath(rootDir);
    string rootWithSep = rootFull.EndsWith(Path.DirectorySeparatorChar)
        ? rootFull
        : rootFull + Path.DirectorySeparatorChar;

    string rel = requestPath.Trim('/');
    string candidate = string.IsNullOrEmpty(rel)
        ? rootFull
        : Path.GetFullPath(Path.Combine(rootFull, rel));

    bool isRoot = string.Equals(candidate, rootFull, StringComparison.OrdinalIgnoreCase);
    bool isInsideRoot = candidate.StartsWith(rootWithSep, StringComparison.OrdinalIgnoreCase);
    if (!isRoot && !isInsideRoot)
    {
        return false;
    }

    if (!Directory.Exists(candidate))
    {
        return false;
    }

    string indexPath = Path.Combine(candidate, "index.html");
    if (File.Exists(indexPath))
    {
        return false;
    }

    fullDirectoryPath = candidate;
    return true;
}

static string BuildDirectoryListingHtml(string rootDir, string targetDir, string requestPath)
{
    string rootFull = Path.GetFullPath(rootDir);
    string normalizedUrlDir = requestPath.EndsWith('/') ? requestPath : requestPath + "/";

    StringBuilder sb = new StringBuilder();
    sb.AppendLine("<!doctype html>");
    sb.AppendLine("<html lang=\"ja\">");
    sb.AppendLine("<head>");
    sb.AppendLine("  <meta charset=\"utf-8\" />");
    sb.AppendLine($"  <title>Index of {WebUtility.HtmlEncode(normalizedUrlDir)}</title>");
    sb.AppendLine("  <style>");
    sb.AppendLine("    body { font-family: sans-serif; margin: 24px; line-height: 1.6; }");
    sb.AppendLine("    ul { list-style: none; padding: 0; }");
    sb.AppendLine("    li { margin: 4px 0; }");
    sb.AppendLine("    a { text-decoration: none; }");
    sb.AppendLine("    a:hover { text-decoration: underline; }");
    sb.AppendLine("  </style>");
    sb.AppendLine("</head>");
    sb.AppendLine("<body>");
    sb.AppendLine($"  <h1>Index of {WebUtility.HtmlEncode(normalizedUrlDir)}</h1>");
    sb.AppendLine("  <ul>");

    if (!string.Equals(Path.GetFullPath(targetDir), rootFull, StringComparison.OrdinalIgnoreCase))
    {
        string parentUrl = GetParentUrlPath(normalizedUrlDir);
        sb.AppendLine($"    <li><a href=\"{WebUtility.HtmlEncode(parentUrl)}\">../ (Parent Directory)</a></li>");
    }

    foreach (string dir in Directory.GetDirectories(targetDir).OrderBy(d => d, StringComparer.OrdinalIgnoreCase))
    {
        string dirName = Path.GetFileName(dir);
        if (string.IsNullOrEmpty(dirName) || dirName.StartsWith('.'))
        {
            continue;
        }
        string href = normalizedUrlDir + Uri.EscapeDataString(dirName) + "/";
        sb.AppendLine($"    <li>[DIR] <a href=\"{href}\">{WebUtility.HtmlEncode(dirName)}/</a></li>");
    }

    foreach (string file in Directory.GetFiles(targetDir).OrderBy(f => f, StringComparer.OrdinalIgnoreCase))
    {
        string fileName = Path.GetFileName(file);
        if (string.IsNullOrEmpty(fileName) || fileName.StartsWith('.'))
        {
            continue;
        }
        string href = normalizedUrlDir + Uri.EscapeDataString(fileName);
        FileInfo info = new FileInfo(file);
        sb.AppendLine($"    <li><a href=\"{href}\">{WebUtility.HtmlEncode(fileName)}</a> <small>({info.Length} bytes)</small></li>");
    }

    sb.AppendLine("  </ul>");
    sb.AppendLine("</body>");
    sb.AppendLine("</html>");
    return sb.ToString();
}

static string GetParentUrlPath(string normalizedDirPath)
{
    string trimmed = normalizedDirPath.Trim('/');
    if (string.IsNullOrEmpty(trimmed))
    {
        return "/";
    }
    int lastSlash = trimmed.LastIndexOf('/');
    if (lastSlash < 0)
    {
        return "/";
    }
    return "/" + trimmed[..lastSlash] + "/";
}

static string GetContentType(string filePath) => Path.GetExtension(filePath).ToLowerInvariant() switch
{
    ".html" or ".htm" => "text/html; charset=utf-8",
    ".css" => "text/css; charset=utf-8",
    ".js" or ".mjs" => "application/javascript; charset=utf-8",
    ".json" => "application/json; charset=utf-8",
    ".svg" => "image/svg+xml",
    ".png" => "image/png",
    ".jpg" or ".jpeg" => "image/jpeg",
    ".gif" => "image/gif",
    ".webp" => "image/webp",
    ".woff2" => "font/woff2",
    ".wasm" => "application/wasm",
    _ => "application/octet-stream"
};


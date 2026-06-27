using Microsoft.ClearScript.V8;
using MultiHtmlCraft.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace MultiHtmlCraft.Core
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.ClearScript.V8;


    namespace MultiHtmlCraft.Core
    {
        /// <summary>
        /// JavaScript Fetch class 
        /// </summary>
        public class CHtmlFetch : ICHtmlFetchInterface
        {
            private readonly HttpClient _httpClient;
            private HttpResponseMessage? _responseMessage;
            private byte[]? _rawContent;
            private bool _bodyUsed = false;

            // --- W3C Request Properties (Initial State) ---
            public string method { get; private set; } = "GET";
            public Uri url { get; private set; }
            public IDictionary<string, string> headers { get; private set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            public object? body { get; private set; }
            public string? mode { get; set; } = "cors";
            public string? credentials { get; set; } = "same-origin";
            public string? cache { get; set; } = "default";
            public string? redirect { get; set; } = "follow";
            public string? referrer { get; set; } = "about:client";
            public string? referrerPolicy { get; set; }
            public string? integrity { get; set; }
            public string? destination { get; set; }
            public bool? keepalive { get; set; } = false;
            public object? signal { get; set; }

            // --- W3C Response Properties ---
            public string type => "basic"; 
            public string urlResponse => _responseMessage?.RequestMessage?.RequestUri?.ToString() ?? url.ToString();
            public bool redirected => false; 
            public int status => _responseMessage != null ? (int)_responseMessage.StatusCode : 0;
            public bool ok => status >= 200 && status <= 299;
            public string statusText => _responseMessage?.ReasonPhrase ?? "";
            public IDictionary<string, string> responseHeaders { get; private set; } = new Dictionary<string, string>();
            public bool bodyUsed => _bodyUsed;
            public object? bodyResponse => _rawContent;

            public CHtmlFetch(Uri uri, HttpClient httpClient)
            {
                url = uri;
                _httpClient = httpClient;
            }

            // --- Internal Fetch Logic ---
            public async Task<CHtmlFetch> ExecuteAsync(string method, dynamic? options)
            {
                this.method = method?.ToUpper() ?? "GET";

                using var request = new HttpRequestMessage(new HttpMethod(this.method), url);

                // ヘッダーの設定
                if (options?.headers != null)
                {
                    foreach (var header in options.headers)
                    {
                        string key = header.Key;
                        string value = header.Value.ToString();
                        headers[key] = value;
                        request.Headers.TryAddWithoutValidation(key, value);
                    }
                }

                _responseMessage = await _httpClient.SendAsync(request);
                _rawContent = await _responseMessage.Content.ReadAsByteArrayAsync();

                // レスポンスヘッダーの抽出
                foreach (var header in _responseMessage.Headers)
                    responseHeaders[header.Key] = string.Join(", ", header.Value);

                return this;
            }

            // --- Response Methods ---
            public async Task<string> text()
            {
                CheckBodyUsed();
                return await Task.FromResult(System.Text.Encoding.UTF8.GetString(_rawContent ?? Array.Empty<byte>()));
            }

            public async Task<object> json()
            {
                var txt = await text();
             
                //return V8ScriptEngine.GetCurrent().Evaluate($"JSON.parse({@$"'{txt.Replace("'", "\\'")}'"})");
                return string.Empty;
            }

            public async Task<byte[]> arrayBuffer()
            {
                CheckBodyUsed();
                return await Task.FromResult(_rawContent ?? Array.Empty<byte>());
            }

            public async Task<object> blob() => throw new NotImplementedException("Blob implementation requires additional JS-binding logic.");

            public async Task<object> formData() => throw new NotImplementedException("FormData parsing logic is complex and requires multipart/form-data parsing.");

            public ICHtmlFetchInterface clone()
            {
                // インスタンスのコピーを返す
                return (ICHtmlFetchInterface)this.MemberwiseClone();
            }

            private void CheckBodyUsed()
            {
                if (_bodyUsed) throw new InvalidOperationException("Body has already been used.");
                _bodyUsed = true;
            }
        }
    }

    /// <summary>
    /// fetch response
    /// </summary>
    public class CHtmlFetchResponse
    {
        private readonly HttpResponseMessage _res;
        private readonly string _content;

        public CHtmlFetchResponse(HttpResponseMessage res, string content)
        {
            _res = res;
            _content = content;
        }

  
        public int status => (int)_res.StatusCode;
        public bool ok => _res.IsSuccessStatusCode;
        public string statusText => _res.ReasonPhrase;


        public Task<string> text() => Task.FromResult(_content);

        public object json()
        {

            //return V8ScriptEngine.GetCurrent().Evaluate($"JSON.parse({@$"'{_content.Replace("'", "\\'")}'"})");
            return string.Empty;
        }
    }
}
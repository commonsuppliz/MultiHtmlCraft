using Avalonia.Input;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using MultiHtmlCraft.Core;
using MultiHtmlCraft.Interfaces;
using MultiHtmlCraft.Interfaces;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Dynamic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Core
    {
        /// <summary>
        /// JavaScript Fetch class 
        /// </summary>
        public class CHtmlFetch : ICHtmlFetchInterface, IDynamicMetaObjectProvider
        {

        private WeakReference<ScriptEngine>? _engineRef;

        public ScriptEngine? v8ScriptEngine
        {
            get => _engineRef != null && _engineRef.TryGetTarget(out var eng) ? eng : null;
            set => _engineRef = value != null ? new WeakReference<ScriptEngine>(value) : null;
        }

        private static HttpClient ___httpClient = CHtmlMultiversalWindow.getHttpClient();
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

       
        
            public CHtmlFetch(Uri uri)
            {
                if(commonLog.LoggingEnabled) commonLog.LogEntry($"CHtmlFetch: Initialized with URL: {uri}");
                url = uri;
            }
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new CHtmlClearScriptDynamicMetaObject<CHtmlFetch>(parameter, this);
        }

        // --- Internal Fetch Logic ---

        public async Task<CHtmlFetch> ExecuteAsync(
            string method,
            JsonElement options,
            CancellationToken cancellationToken = default)
        {
            this.method = string.IsNullOrWhiteSpace(method)
                ? "GET"
                : method.ToUpperInvariant();

            using var request =
                new HttpRequestMessage(
                    new HttpMethod(this.method),
                    url);

            JsonElement headersElement = default;
            bool hasHeaders =
                options.TryGetProperty("resquestGetHeaders", out headersElement);

            string? contentType = null;

            if (hasHeaders &&
                headersElement.ValueKind == JsonValueKind.Object)
            {
                foreach (JsonProperty header in headersElement.EnumerateObject())
                {
                    string key = header.Name;
                    string value = header.Value.GetString() ?? string.Empty;

                    headers[key] = value;

                    if (string.Equals(
                            key,
                            "Content-Type",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        contentType = value;
                    }
                    else
                    {
                        request.Headers.TryAddWithoutValidation(key, value);
                    }
                }
            }

            if (options.TryGetProperty("body", out JsonElement bodyElement) &&
                bodyElement.ValueKind != JsonValueKind.Null &&
                !string.Equals(this.method, "GET", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(this.method, "HEAD", StringComparison.OrdinalIgnoreCase))
            {
                string bodyJson = bodyElement.GetRawText();

                string mediaType = "application/json";

                if (!string.IsNullOrWhiteSpace(contentType))
                {
                    int separatorIndex = contentType.IndexOf(';');

                    mediaType = separatorIndex >= 0
                        ? contentType[..separatorIndex].Trim()
                        : contentType.Trim();
                }

                request.Content = new StringContent(
                    bodyJson,
                    Encoding.UTF8,
                    mediaType);
            }

            _responseMessage =
                await ___httpClient.SendAsync(
                    request,
                    cancellationToken);

            _rawContent =
                await _responseMessage.Content.ReadAsByteArrayAsync(
                    cancellationToken);

            foreach (var header in _responseMessage.Headers)
            {
                responseHeaders[header.Key] =
                    string.Join(", ", header.Value);
            }

            foreach (var header in _responseMessage.Content.Headers)
            {
                responseHeaders[header.Key] =
                    string.Join(", ", header.Value);
            }

            return this;
        }



        public async Task<CHtmlFetchResponse> ____fetchExecuteAsync(
string method,
JsonElement jsonElement,
CancellationToken cancellationToken = default)
        {
            return new CHtmlFetchResponse();
        }

        public async Task<CHtmlFetchResponse> ____fetchExecuteAsync(
    string method,
    Dictionary<string, object>? resquestGetHeaders,
    CancellationToken cancellationToken = default)
        {
            this.method = string.IsNullOrWhiteSpace(method)
                ? "GET"
                : method.ToUpperInvariant();

            using var request =
                new HttpRequestMessage(
                    new HttpMethod(this.method),
                    url);
            foreach(string headerKey in resquestGetHeaders.Keys)
            {
                if (!string.IsNullOrEmpty(headerKey))
                {
                    object? headerValue = null;
                    if (resquestGetHeaders.TryGetValue(headerKey, out headerValue))
                    {
                        switch(headerKey)
                        {
                            default:
                                break;
                        }

                    }
                }
            }



            string? contentType = null;
     



           
   using HttpResponseMessage httpclientresponse = await ___httpClient.SendAsync(
    request,
    HttpCompletionOption.ResponseHeadersRead,
    cancellationToken);

            _rawContent =
                await httpclientresponse.Content.ReadAsByteArrayAsync(
                    cancellationToken);
            CHtmlFetchResponse fetchResponse = new CHtmlFetchResponse(httpclientresponse, _rawContent);
            if (this.v8ScriptEngine != null)
            {
                fetchResponse.v8ScriptEngine = this.v8ScriptEngine;
            }

            return fetchResponse;
        }



        public Task<object> json()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> arrayBuffer()
        {
            throw new NotImplementedException();
        }

        public Task<object> blob()
        {
            throw new NotImplementedException();
        }

        public Task<object> formData()
        {
            throw new NotImplementedException();
        }

        public ICHtmlFetchInterface clone()
        {
            throw new NotImplementedException();
        }





        public async Task<string> text()
            {
                CheckBodyUsed();
                return await Task.FromResult(System.Text.Encoding.UTF8.GetString(_rawContent ?? Array.Empty<byte>()));
            }





 



            private void CheckBodyUsed()
            {
                if (_bodyUsed) throw new InvalidOperationException("Body has already been used.");
                _bodyUsed = true;
            }
        }
    }

/// <summary>
/// fetch httpclientresponse
/// </summary>

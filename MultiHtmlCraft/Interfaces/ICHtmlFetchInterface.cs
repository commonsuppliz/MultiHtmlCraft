using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    /// <summary>
    /// C#版 Fetch Standard Request/Response インターフェイス (W3C準拠)
    /// </summary>
    public interface ICHtmlFetchInterface
    {
        // Request properties (W3C names)
        string method { get; }
        Uri url { get; }
        IDictionary<string, string> headers { get; }
        object? body { get; }
        string? mode { get; }
        string? credentials { get; }
        string? cache { get; }
        string? redirect { get; }
        string? referrer { get; }
        string? referrerPolicy { get; }
        string? integrity { get; }
        string? destination { get; }
        bool? keepalive { get; }
        object? signal { get; }

        // Response properties (W3C Fetch API)
        string type { get; } // basic, cors, default, error, opaque, opaqueredirect
        string urlResponse { get; } // response.url
        bool redirected { get; } // response.redirected
        int status { get; } // response.status
        bool ok { get; } // response.ok
        string statusText { get; } // response.statusText
        IDictionary<string, string> responseHeaders { get; } // response.headers
        bool bodyUsed { get; } // response.bodyUsed
        object? bodyResponse { get; } // response.body

        // Response methods (W3C names)
        Task<string> text();
        Task<object> json();
        Task<byte[]> arrayBuffer();
        Task<object> blob();
        Task<object> formData();
        ICHtmlFetchInterface clone();
    }
}
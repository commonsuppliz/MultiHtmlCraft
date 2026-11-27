using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlWebSocket : IAsyncDisposable
    {
        Uri? Url { get; }
        string? SubProtocol { get; }
        bool IsOpen { get; }

        Task ConnectAsync(Uri uri, CancellationToken cancellationToken = default);
        Task SendTextAsync(string message, CancellationToken cancellationToken = default);
        Task SendBinaryAsync(ReadOnlyMemory<byte> data, CancellationToken cancellationToken = default);
        Task CloseAsync(int code = 1000, string? reason = null, CancellationToken cancellationToken = default);

        event Action? Opened;
        event Action<string>? TextReceived;
        event Action<byte[]>? BinaryReceived;
        event Action<Exception>? ErrorOccurred;
        event Action<int, string?, bool>? Closed;
    }
}

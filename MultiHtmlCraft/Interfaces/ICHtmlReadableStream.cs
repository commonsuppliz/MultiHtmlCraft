using System;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    // 1. 戻り値の型（struct版に統一。recordは削除しました）
    public struct StreamReadResult<T>
    {
        public T Value { get;  } 
        public bool Done { get;  }

        public StreamReadResult(T value, bool done)
        {
            Value = value;
            Done = done;
        }
    }

    // 2. リーダーのインターフェース
    public interface IStreamReader<T> : IDisposable
    {
        ValueTask<StreamReadResult<T>> ReadAsync();
    }

    // 3. ストリーム本体
    public interface IReadableStream<T>
    {
        bool IsLocked { get; }
        IStreamReader<T> GetReader();
    }
}
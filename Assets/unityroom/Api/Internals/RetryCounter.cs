using System;

namespace unityroom.Api.Internals
{
    internal class RetryCounter
    {
        private readonly int _maxRetryCount;

        internal RetryCounter(int maxRetryCount)
        {
            _maxRetryCount = maxRetryCount;
        }

        internal bool CanRetry => Count < _maxRetryCount;
        internal int Count { get; private set; } = 0;

        internal void Reset()
        {
            Count = 0;
        }

        internal void Increment()
        {
            if (!CanRetry) throw new InvalidOperationException("リトライ可能数を超過しています。");
            Count++;
        }
    }
}
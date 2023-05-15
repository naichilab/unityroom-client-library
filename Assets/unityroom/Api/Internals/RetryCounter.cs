using System;

namespace unityroom.Api.Internals
{
    internal class RetryCounter
    {
        private readonly int _maxTryCount;

        internal RetryCounter(int maxTryCount)
        {
            _maxTryCount = maxTryCount;
        }

        internal bool CanRetry => Count < _maxTryCount;
        internal int Count { get; private set; } = 0;
        internal int RemainCount => _maxTryCount - Count;

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
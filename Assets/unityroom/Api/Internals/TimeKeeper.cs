namespace unityroom.Api.Internals
{
    /// <summary>
    /// リクエスト送信間隔を管理
    /// </summary>
    internal class TimeKeeper
    {
        private readonly int _intervalSeconds;
        private int _lastSentTime = int.MinValue;

        internal TimeKeeper(int intervalSeconds)
        {
            _intervalSeconds = intervalSeconds;
        }

        internal bool IsBusy() => IsBusy(UnixTime.GetCurrentUnixTime());

        internal bool IsBusy(int now)
        {
            return _lastSentTime + _intervalSeconds > now;
        }

        internal void Reset() => Reset(UnixTime.GetCurrentUnixTime());

        internal void Reset(int now)
        {
            _lastSentTime = now;
        }
    }
}
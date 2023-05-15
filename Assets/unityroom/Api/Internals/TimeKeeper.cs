namespace unityroom.Api.Internals
{
    /// <summary>
    /// リクエスト送信間隔を管理
    /// </summary>
    internal class TimeKeeper
    {
        private readonly int _intervalSeconds;
        private float _lastSentTime = float.MinValue;

        internal TimeKeeper(int intervalSeconds)
        {
            _intervalSeconds = intervalSeconds;
        }

        internal bool IsBusy(float now) => _lastSentTime + _intervalSeconds > now;

        internal void Reset(float now)
        {
            _lastSentTime = now;
        }
    }
}
using UnityEngine;

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

        internal bool IsBusy => _lastSentTime + _intervalSeconds > Time.time;

        internal void Reset()
        {
            _lastSentTime = Time.time;
        }
    }
}
using System;

namespace unityroom.Api.Internals
{
    internal static class UnixTime
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 現在時刻のUnixTimeを返す
        /// </summary>
        /// <returns></returns>
        internal static int GetCurrentUnixTime()
        {
            return ToUnixTime(DateTime.Now);
        }

        private static int ToUnixTime(DateTime targetTime)
        {
            targetTime = targetTime.ToUniversalTime();
            var elapsedTime = targetTime - UnixEpoch;
            return (int)elapsedTime.TotalSeconds;
        }
    }
}
using System;

namespace unityroom.Api.Internals
{
    internal static class UnixTime
    {
        /// <summary>
        /// 現在時刻のUnixTimeを返す
        /// </summary>
        /// <returns></returns>
        internal static int GetCurrentUnixTime()
        {
            return (int)(DateTime.UtcNow.Subtract(DateTime.UnixEpoch)).TotalSeconds;
        }
    }
}
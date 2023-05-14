namespace unityroom.Api.Internals
{
    internal static class Util
    {
        /// <summary>
        /// Unityエディタで実行中かどうか
        /// </summary>
        /// <returns></returns>
        internal static bool IsEditor()
        {
#if UNITY_EDITOR
            return true;
#else
        return false;
#endif
        }
    }
}
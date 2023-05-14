using unityroom.Api;

namespace unityroom
{
    public interface IUnityroomApiClient
    {
        void SendScore(
            int boardNo
            , float score
            , ScoreboardWriteMode mode
        );
    }
}
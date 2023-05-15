namespace unityroom.Api
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
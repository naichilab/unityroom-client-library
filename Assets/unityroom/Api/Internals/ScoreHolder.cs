using System;

namespace unityroom.Api.Internals
{
    /// <summary>
    /// ハイスコアを記録する
    /// </summary>
    internal class ScoreHolder
    {
        private float? _currentScore = null;
        internal float Score
        {
            get
            {
                if (_currentScore != null) return _currentScore.Value;
                throw new InvalidOperationException("スコア未登録です");
            }
        }
        internal bool ScoreChanged { get; private set; } = false;

        /// <summary>
        /// 新しいスコアを記録
        /// </summary>
        /// <param name="score">記録するスコア</param>
        /// <param name="mode">スコア更新ルール</param>
        /// <returns></returns>
        internal bool SetNewScore(float score, ScoreboardWriteMode mode)
        {
            if (!_currentScore.HasValue || mode == ScoreboardWriteMode.Always ||
                (mode == ScoreboardWriteMode.HighScoreDesc && _currentScore.Value < score) ||
                (mode == ScoreboardWriteMode.HighScoreAsc && _currentScore.Value > score))
            {
                _currentScore = score;
                ScoreChanged = true;
                return true;
            }

            return false;
        }

        internal void ResetChangedFlag()
        {
            ScoreChanged = false;
        }
    }
}
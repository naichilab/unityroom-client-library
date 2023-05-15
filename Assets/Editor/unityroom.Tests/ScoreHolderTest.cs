using NUnit.Framework;
using unityroom.Api;
using unityroom.Api.Internals;

namespace Editor.unityroom.Tests
{
    public class ScoreHolderTest
    {
        [Test]
        public void ScoreHolderTest_スコア未記録()
        {
            var h = new ScoreHolder();
            Assert.False(h.ScoreChanged);
            Assert.Catch(
                () =>
                {
                    var x = h.Score;
                }
            );
        }

        [Test]
        public void ScoreHolderTest_スコア記録_常に()
        {
            var h = new ScoreHolder();
            Assert.True(h.SetNewScore(123.45f, ScoreboardWriteMode.Always));
            Assert.AreEqual(123.45f, h.Score);
            Assert.True(h.SetNewScore(32f, ScoreboardWriteMode.Always));
            Assert.AreEqual(32f, h.Score);
            Assert.True(h.SetNewScore(300.5f, ScoreboardWriteMode.Always));
            Assert.AreEqual(300.5f, h.Score);
        }

        [Test]
        public void ScoreHolderTest_スコア記録_ハイスコア降順()
        {
            var h = new ScoreHolder();
            Assert.True(h.SetNewScore(123.45f, ScoreboardWriteMode.HighScoreDesc));
            Assert.AreEqual(123.45f, h.Score);
            Assert.False(h.SetNewScore(32f, ScoreboardWriteMode.HighScoreDesc));
            Assert.AreEqual(123.45f, h.Score);
            Assert.True(h.SetNewScore(300.5f, ScoreboardWriteMode.HighScoreDesc));
            Assert.AreEqual(300.5f, h.Score);
        }

        [Test]
        public void ScoreHolderTest_スコア記録_ハイスコア昇順()
        {
            var h = new ScoreHolder();
            Assert.True(h.SetNewScore(123.45f, ScoreboardWriteMode.HighScoreAsc));
            Assert.AreEqual(123.45f, h.Score);
            Assert.True(h.SetNewScore(32f, ScoreboardWriteMode.HighScoreAsc));
            Assert.AreEqual(32f, h.Score);
            Assert.False(h.SetNewScore(300.5f, ScoreboardWriteMode.HighScoreAsc));
            Assert.AreEqual(32f, h.Score);
        }
    }
}
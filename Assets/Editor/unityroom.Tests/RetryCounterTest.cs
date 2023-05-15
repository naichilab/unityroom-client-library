using NUnit.Framework;
using unityroom.Api.Internals;

namespace Editor.unityroom.Tests
{
    public class RetryCounterTest
    {
        [Test]
        public void RetryCounterTestSimplePasses()
        {
            var c = new RetryCounter(2);
            Assert.AreEqual(0, c.Count);
            Assert.AreEqual(2, c.RemainCount);
            Assert.True(c.CanRetry);
            c.Increment(); //0=>1
            Assert.AreEqual(1, c.Count);
            Assert.AreEqual(1, c.RemainCount);
            Assert.True(c.CanRetry);
            c.Increment(); //1=>2
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.RemainCount);
            Assert.False(c.CanRetry);
        }
    }
}
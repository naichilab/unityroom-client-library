using NUnit.Framework;
using unityroom.Api.Internals;

namespace Editor.unityroom.Tests
{
    public class RetryCounterTest
    {
        [Test]
        public void RetryCounterTestSimplePasses()
        {
            var c = new RetryCounter(3);
            Assert.True(c.CanRetry);
            c.Increment(); //0=>1
            Assert.True(c.CanRetry);
            c.Increment(); //1=>2
            Assert.True(c.CanRetry);
            c.Increment(); //2=>3
            Assert.False(c.CanRetry);
        }
    }
}
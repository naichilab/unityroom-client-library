using NUnit.Framework;
using unityroom.Api.Internals;

namespace Editor.unityroom.Tests
{
    public class TimeKeeperTest
    {
        [Test]
        public void TimeKeeperTestSimplePasses()
        {
            var timeKeeper = new TimeKeeper(3);
            Assert.False(timeKeeper.IsBusy(100));
            timeKeeper.Reset(110);
            Assert.True(timeKeeper.IsBusy(111));
            Assert.True(timeKeeper.IsBusy(112));
            Assert.True(timeKeeper.IsBusy(112.9f));
            Assert.False(timeKeeper.IsBusy(113.1f));
            Assert.False(timeKeeper.IsBusy(114));
        }
    }
}
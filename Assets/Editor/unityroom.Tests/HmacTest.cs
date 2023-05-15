using NUnit.Framework;

namespace Editor.unityroom.Tests
{
    public class HmacTest
    {
        [Test]
        public void HmacTestSimplePasses()
        {
            var dataText = "abc";
            var keyBase64 = "lXrUx6mFYIiaAOErV9qBF697sgH44+Sy+7dJN03hN/egrnOs97c8D/tAEpP4LGqq/nK5IXypReR227qyiYUjqg==";
            var result = "f5107be800b7fd02d38f4cd638745941b545554e9f45faa9c25628e998a7fbe7";
            Assert.AreEqual(result, global::unityroom.Api.Internals.Hmac.GetHmacSha256(dataText, keyBase64));
        }
    }
}
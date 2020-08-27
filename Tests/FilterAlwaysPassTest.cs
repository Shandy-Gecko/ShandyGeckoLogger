using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
    public class FilterAlwaysPassTest
    {
        private FilterAlwaysPass _filterAlwaysPass;
        
        [SetUp]
        public void OnSetUp()
        {
            _filterAlwaysPass = new FilterAlwaysPass();
        }

        [TearDown]
        public void OnTearDown()
        {
            _filterAlwaysPass = null;
        }

        [TestCase(MessageType.Trace)]
        [TestCase(MessageType.Debug)]
        [TestCase(MessageType.Info)]
        [TestCase(MessageType.Debug)]
        [TestCase(MessageType.Warning)]
        [TestCase(MessageType.Error)]
        [TestCase(MessageType.Critical)]
        public void IsTagPassedTest(MessageType messageType)
        {
            Assert.True(_filterAlwaysPass.IsPassed(messageType, "TEST"));
        }
        
        [TestCase(MessageType.Trace)]
        [TestCase(MessageType.Debug)]
        [TestCase(MessageType.Info)]
        [TestCase(MessageType.Debug)]
        [TestCase(MessageType.Warning)]
        [TestCase(MessageType.Error)]
        [TestCase(MessageType.Critical)]
        public void IsTypePassedTest(MessageType messageType)
        {
            Assert.True(_filterAlwaysPass.IsPassed(messageType, new object()));
        }
    }
}
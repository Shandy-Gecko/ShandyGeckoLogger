using System.Linq;
using NUnit.Framework;
using ShandyGecko.LogSystem.Tests.FakeLoggers;

namespace ShandyGecko.LogSystem.Tests
{
    public class LogTests
    {
        private const string TestTag = "TestTag";
        private const string TestMsg = "TestMessage";
        
        private Formatter _formatter;
        private FakeLogger _fakeLogger;
        
        [SetUp]
        public void OnSetup()
        {
            _formatter = new Formatter();
            _fakeLogger = new FakeLogger();

            Log.CompoundLogger.ClearLoggers();
            Log.CompoundLogger.SetLoggers(_fakeLogger);
        }
        
        [Test]
        public void TraceTagTest()
        {
            Log.Trace(TestTag, TestMsg);
            
            var expectedMessage = GetExpectedMessage(MessageType.Trace, TestTag, TestMsg);
            var actualMessage = _fakeLogger.LoggedEvents.Last();
            
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        
        [Test]
        public void TraceObjTest()
        {
            
        }

        private string GetExpectedMessage(MessageType messageType, string tag, string message)
        {
            return _formatter.Format(messageType, tag, message);
        }

        private string GetExpectedMessage(MessageType messageType, object obj, string message)
        {
            return _formatter.Format(messageType, obj, message);
        }
    }
}

#define TRACE_LOGS

using System;
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
        private object _testObject;
        
        [SetUp]
        public void OnSetup()
        {
            _formatter = new Formatter();
            _fakeLogger = new FakeLogger();
            _testObject = new object();

            Log.CompoundLogger.ClearLoggers();
            Log.CompoundLogger.SetLoggers(_fakeLogger);
        }
        
        [Test]
        public void TraceTagTest()
        {
            Log.Trace(TestTag, TestMsg);
            
            AssetLoggedEventWithTag(MessageType.Trace);
        }
        
        [Test]
        public void TraceObjTest()
        {
            Log.Trace(_testObject, TestMsg);
            
            AssetLoggedEventWithObj(MessageType.Trace);
        }

        private void AssetLoggedEventWithTag(MessageType messageType)
        {
            var expectedMessage = GetExpectedMessage(messageType, TestTag, TestMsg);
            var actualMessage = _fakeLogger.LoggedEvents.Last();
            
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        
        private void AssetLoggedEventWithObj(MessageType messageType)
        {
            var expectedMessage = GetExpectedMessage(messageType, _testObject, TestMsg);
            var actualMessage = _fakeLogger.LoggedEvents.Last();
            
            Assert.AreEqual(expectedMessage, actualMessage);
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

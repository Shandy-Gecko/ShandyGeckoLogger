#define TRACE_LOGS
#define DEBUG_LOGS
#define INFO_LOGS
#define WARNING_LOGS
#define ERROR_LOGS
#define CRITICAL_LOGS

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
        
        [Test]
        public void DebugTagTest()
        {
            Log.Debug(TestTag, TestMsg);
            
            AssetLoggedEventWithTag(MessageType.Debug);
        }
        
        [Test]
        public void DebugObjTest()
        {
            Log.Debug(_testObject, TestMsg);
            
            AssetLoggedEventWithObj(MessageType.Debug);
        }
        
        [Test]
        public void InfoTagTest()
        {
            Log.Info(TestTag, TestMsg);
            
            AssetLoggedEventWithTag(MessageType.Info);
        }
        
        [Test]
        public void InfoObjTest()
        {
            Log.Info(_testObject, TestMsg);
            
            AssetLoggedEventWithObj(MessageType.Info);
        }
        
        [Test]
        public void WarningTagTest()
        {
            Log.Warning(TestTag, TestMsg);
            
            AssetLoggedEventWithTag(MessageType.Warning);
        }
        
        [Test]
        public void WarningObjTest()
        {
            Log.Warning(_testObject, TestMsg);
            
            AssetLoggedEventWithObj(MessageType.Warning);
        }
        
        [Test]
        public void ErrorTagTest()
        {
            Log.Error(TestTag, TestMsg);
            
            AssetLoggedEventWithTag(MessageType.Error);
        }
        
        [Test]
        public void ErrorObjTest()
        {
            Log.Error(_testObject, TestMsg);
            
            AssetLoggedEventWithObj(MessageType.Error);
        }
        
        [Test]
        public void CriticalTagTest()
        {
            Log.Critical(TestTag, TestMsg);
            
            AssetLoggedEventWithTag(MessageType.Critical);
        }
        
        [Test]
        public void CriticalObjTest()
        {
            Log.Critical(_testObject, TestMsg);
            
            AssetLoggedEventWithObj(MessageType.Critical);
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

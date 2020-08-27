using System.Linq;
using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;
using ShandyGecko.LogSystem.Tests.FakeLoggers;

namespace ShandyGecko.LogSystem.Tests
{
    public class CompoundLoggerTests
    {
        private const string TestTag = "TraceTag";
        private const string TestMsg = "TraceMsg";
        
        private ICompoundLogger _compoundLogger;
        private object _testObject;
        
        [SetUp]
        public void OnSetup()
        {
            _compoundLogger = new CompoundLogger();
            _testObject = new object();
        }

        [TearDown]
        public void OnTearDown()
        {
            _compoundLogger = null;
            _testObject = null;
        }

        [Test]
        public void GetSetFilterTest()
        {
            var filter = new FilterAlwaysPass();

            _compoundLogger.Filter = filter;
            Assert.AreEqual(filter, _compoundLogger.Filter);
        }

        [Test]
        public void SetLoggersTest()
        {
            var logger = new FakeLogger();
            
            _compoundLogger.SetLoggers(logger);
            
            Assert.Contains(logger, _compoundLogger.Loggers.ToList());
        }
        
        [Test]
        public void ClearLoggersTest()
        {
            var logger = new FakeLogger();
            
            _compoundLogger.SetLoggers(logger);
            
            Assert.IsNotEmpty(_compoundLogger.Loggers);
            
            _compoundLogger.ClearLoggers();
            
            Assert.IsEmpty(_compoundLogger.Loggers);
        }

        [Test]
        public void TryAddLoggerTest()
        {
            var logger = new FakeLogger();
            
            _compoundLogger.TryAddLogger(logger);
         
            Assert.Contains(logger, _compoundLogger.Loggers.ToList());
        }
        
        [Test]
        public void DoubleTryAddLoggerTest()
        {
            var logger = new FakeLogger();
            
            _compoundLogger.TryAddLogger(logger);
         
            Assert.Contains(logger, _compoundLogger.Loggers.ToList());
            Assert.AreEqual(1, _compoundLogger.Loggers.Count());
            
            _compoundLogger.TryAddLogger(logger);
            Assert.AreEqual(1, _compoundLogger.Loggers.Count());
        }

        [Test]
        public void TryRemoveLoggerTest()
        {
            var logger = new FakeLogger();
            
            _compoundLogger.TryAddLogger(logger);
            Assert.IsNotEmpty(_compoundLogger.Loggers);
            
            _compoundLogger.TryRemoveLogger(logger);
            Assert.IsEmpty(_compoundLogger.Loggers);
        }
        
        [Test]
        public void DoubleTryRemoveLoggerTest()
        {
            var logger = new FakeLogger();
            
            _compoundLogger.TryAddLogger(logger);
            Assert.IsNotEmpty(_compoundLogger.Loggers);
            
            _compoundLogger.TryRemoveLogger(logger);
            Assert.IsEmpty(_compoundLogger.Loggers);
            
            _compoundLogger.TryRemoveLogger(logger);
            Assert.IsEmpty(_compoundLogger.Loggers);
        }
        
        [Test]
        public void TraceTagDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Trace(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void TraceObjDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Trace(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void DebugTagDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Debug(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void DebugObjDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Debug(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void InfoTagDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Info(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void InfoObjDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Info(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void WarningTagDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Warning(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void WarningObjDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Warning(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void ErrorTagDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Error(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void ErrorObjDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Error(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void CriticalTagDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Critical(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void CriticalObjDoesNotThrowNoLoggersException()
        {
            _compoundLogger.SetLoggers(new FakeLogger());
            
            Assert.DoesNotThrow(() =>
            {
                _compoundLogger.Critical(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void TraceTagThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Trace(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void TraceObjThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Trace(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void DebugTagThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Debug(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void DebugObjThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Debug(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void InfoTagThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Info(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void InfoObjThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Info(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void WarningTagThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Warning(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void WarningObjThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Warning(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void ErrorTagThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Error(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void ErrorObjThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Error(_testObject, TestMsg);
            });
        }
        
        [Test]
        public void CriticalTagThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Critical(TestTag, TestMsg);
            });
        }
        
        [Test]
        public void CriticalObjThrowNoLoggersException()
        {
            Assert.Throws<NoLoggersException>(() =>
            {
                _compoundLogger.Critical(_testObject, TestMsg);
            });
        }
    }
}
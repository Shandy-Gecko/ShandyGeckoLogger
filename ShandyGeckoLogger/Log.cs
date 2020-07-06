using System;
using System.Diagnostics;

namespace LowPolyShooter.LogSystem
{
    public static class Log
    {
        private const string DebugLogs = "DEBUG_LOGS";
        private const string WarningLogs = "WARNING_LOGS";
        private const string ErrorLogs = "ERROR_LOGS";
        private const string ExceptionLogs = "EXCEPTION_LOGS";
        private const string AssertLogs = "ASSERT_LOGS";

        private static readonly ILogger CompoundLogger;

        static Log()
        {
            CompoundLogger = new CompoundLogger();
        }

        [Conditional(DebugLogs)]
        public static void Debug(string tag, string message)
        {
            CompoundLogger.Debug(tag, message);
        }
        
        [Conditional(DebugLogs)]
        public static void Debug(object obj, string message)
        {
            CompoundLogger.Debug(obj, message);
        }

        [Conditional(WarningLogs)]
        public static void Warning(string tag, string message)
        {
            CompoundLogger.Warning(tag, message);
        }
        
        [Conditional(WarningLogs)]
        public static void Warning(object obj, string message)
        {
            CompoundLogger.Warning(obj, message);
        }

        [Conditional(ErrorLogs)]
        public static void Error(string tag, string message)
        {
            CompoundLogger.Error(tag, message);
        }

        [Conditional(ErrorLogs)]
        public static void Error(object obj, string message)
        {
            CompoundLogger.Error(obj, message);
        }

        [Conditional(ExceptionLogs)]
        public static void Exception(string tag, Exception exception)
        {
            CompoundLogger.Exception(tag, exception);
        }

        [Conditional(ExceptionLogs)]
        public static void Exception(object obj, Exception exception)
        {
            CompoundLogger.Exception(obj, exception);
        }

        [Conditional(AssertLogs)]
        public static void Assertion(string tag, object message)
        {
            CompoundLogger.Assertion(tag, message);
        }

        [Conditional(AssertLogs)]
        public static void Assertion(object obj, object message)
        {
            CompoundLogger.Assertion(obj, message);
        }
    }
}
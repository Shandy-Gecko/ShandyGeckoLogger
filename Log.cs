using System.Diagnostics;

namespace ShandyGecko.LogSystem
{
    public static class Log
    {
        private const string TraceLogs = "TRACE_LOGS";
        private const string DebugLogs = "DEBUG_LOGS";
        private const string InfoLogs = "INFO_LOGS";
        private const string WarningLogs = "WARNING_LOGS";
        private const string ErrorLogs = "ERROR_LOGS";
        private const string CriticalLogs = "CRITICAL_LOGS";

        public static ICompoundLogger CompoundLogger { get; private set; }

        static Log()
        {
            CompoundLogger = new CompoundLogger();
        }

        [Conditional(TraceLogs)]
        public static void Trace(string tag, string message)
        {
            CompoundLogger.Trace(tag, message);
        }
        
        [Conditional(TraceLogs)]
        public static void Trace(object obj, string message)
        {
            CompoundLogger.Trace(obj, message);
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
        
        [Conditional(InfoLogs)]
        public static void Info(string tag, string message)
        {
            CompoundLogger.Info(tag, message);
        }
        
        [Conditional(InfoLogs)]
        public static void Info(object obj, string message)
        {
            CompoundLogger.Info(obj, message);
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
        
        [Conditional(CriticalLogs)]
        public static void Critical(string tag, string message)
        {
            CompoundLogger.Critical(tag, message);
        }

        [Conditional(ErrorLogs)]
        public static void Critical(object obj, string message)
        {
            CompoundLogger.Critical(obj, message);
        }
    }
}
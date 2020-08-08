namespace ShandyGecko.LogSystem
{
    public interface ILogger
    {
        void Trace(string tag, string message);
        void Trace(object obj, string message);
        void Debug(string tag, string message);
        void Debug(object obj, string message);
        void Info(string tag, string message);
        void Info(object obj, string message);
        void Warning(string tag, string message);
        void Warning(object obj, string message);
        void Error(string tag, string message);
        void Error(object obj, string message);
        void Critical(string tag, string message);
        void Critical(object obj, string message);
    }
}
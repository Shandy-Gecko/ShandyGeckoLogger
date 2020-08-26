namespace ShandyGecko.LogSystem
{
    public abstract class BaseLogger : ILogger
    {
        private readonly Formatter _formatter = new Formatter();
        
        public abstract void Trace(string tag, string message);
        public abstract void Trace(object obj, string message);

        public abstract void Debug(string tag, string message);
        public abstract void Debug(object obj, string message);

        public abstract void Info(string tag, string message);
        public abstract void Info(object obj, string message);

        public abstract void Warning(string tag, string message);
        public abstract void Warning(object obj, string message);

        public abstract void Error(string tag, string message);
        public abstract void Error(object obj, string message);

        public abstract void Critical(string tag, string message);
        public abstract void Critical(object obj, string message);

        protected string GetFormattedMessage(MessageType msgType, string tag, string message)
        {
            return _formatter.Format(msgType, tag, message);
        }
        
        protected string GetFormattedMessage(MessageType msgType, object obj, string message)
        {
            return _formatter.Format(msgType, obj, message);
        }
    }
}
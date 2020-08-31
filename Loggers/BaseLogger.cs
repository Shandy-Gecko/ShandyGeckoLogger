namespace ShandyGecko.LogSystem
{
    public abstract class BaseLogger : ILogger
    {

        private IFormatter _formatter;
        public IFormatter Formatter
        {
            get => _formatter ?? (_formatter = new DefaultFormatter());
            set => _formatter = value;
        }

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
            return Formatter.Format(msgType, tag, message);
        }
        
        protected string GetFormattedMessage(MessageType msgType, object obj, string message)
        {
            return Formatter.Format(msgType, obj, message);
        }
    }
}
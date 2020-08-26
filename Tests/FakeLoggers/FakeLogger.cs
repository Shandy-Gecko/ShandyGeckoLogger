using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Tests.FakeLoggers
{
    internal class FakeLogger : BaseLogger
    {
        private readonly List<string> _loggedEvents = new List<string>();

        public IEnumerable<string> LoggedEvents => _loggedEvents;
        
        public override void Trace(string tag, string message)
        {
            AddLoggedEvent(MessageType.Trace, tag, message);
        }

        public override void Trace(object obj, string message)
        {
            AddLoggedEvent(MessageType.Trace, obj, message);
        }

        public override void Debug(string tag, string message)
        {
            AddLoggedEvent(MessageType.Debug, tag, message);
        }

        public override void Debug(object obj, string message)
        {
            AddLoggedEvent(MessageType.Debug, obj, message);
        }

        public override void Info(string tag, string message)
        {
            AddLoggedEvent(MessageType.Info, tag, message);
        }

        public override void Info(object obj, string message)
        {
            AddLoggedEvent(MessageType.Info, obj, message);
        }

        public override void Warning(string tag, string message)
        {
            AddLoggedEvent(MessageType.Warning, tag, message);
        }

        public override void Warning(object obj, string message)
        {
            AddLoggedEvent(MessageType.Warning, obj, message);
        }

        public override void Error(string tag, string message)
        {
            AddLoggedEvent(MessageType.Error, tag, message);
        }

        public override void Error(object obj, string message)
        {
            AddLoggedEvent(MessageType.Error, obj, message);
        }

        public override void Critical(string tag, string message)
        {
            AddLoggedEvent(MessageType.Critical, tag, message);
        }

        public override void Critical(object obj, string message)
        {
            AddLoggedEvent(MessageType.Critical, obj, message);
        }

        private void AddLoggedEvent(MessageType type, string tag, string message)
        {
            _loggedEvents.Add(GetFormattedMessage(type, tag, message));
        }

        private void AddLoggedEvent(MessageType type, object obj, string message)
        {
            _loggedEvents.Add(GetFormattedMessage(type, obj, message));
        }
    }
}
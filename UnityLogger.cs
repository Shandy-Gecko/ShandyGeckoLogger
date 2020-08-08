#if UNITY_5_3_OR_NEWER

namespace ShandyGecko.LogSystem
{
    public class UnityLogger : ILogger
    {
        private readonly Formatter _formatter = new Formatter();

        public void Trace(string tag, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(MessageType.Trace, tag, message));
        }

        public void Trace(object obj, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(MessageType.Trace, obj, message));
        }

        public void Debug(string tag, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(tag, message));
        }

        public void Debug(object obj, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(obj, message));
        }

        public void Info(string tag, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(MessageType.Info, tag, message));
        }

        public void Info(object obj, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(MessageType.Info, obj, message));
        }

        public void Warning(string tag, string message)
        {
            UnityEngine.Debug.LogWarning(_formatter.Format(tag, message));
        }

        public void Warning(object obj, string message)
        {
            UnityEngine.Debug.LogWarning(_formatter.Format(obj, message));
        }

        public void Error(string tag, string message)
        {
            UnityEngine.Debug.LogError(_formatter.Format(tag, message));
        }

        public void Error(object obj, string message)
        {
            UnityEngine.Debug.LogError(_formatter.Format(obj, message));
        }

        public void Critical(string tag, string message)
        {
            UnityEngine.Debug.LogError(_formatter.Format(MessageType.Critical, tag, message));
        }

        public void Critical(object obj, string message)
        {
            UnityEngine.Debug.LogError(_formatter.Format(MessageType.Critical, obj, message));
        }
    }
}
#endif
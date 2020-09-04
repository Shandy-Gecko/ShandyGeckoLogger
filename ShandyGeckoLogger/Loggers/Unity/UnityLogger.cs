#if UNITY_5_3_OR_NEWER

namespace ShandyGecko.LogSystem
{
    public class UnityLogger : BaseLogger
    {
        public override void Trace(string tag, string message)
        {
            UnityEngine.Debug.Log(GetFormattedMessage(MessageType.Trace, tag, message));
        }

        public override void Trace(object obj, string message)
        {
            UnityEngine.Debug.Log(GetFormattedMessage(MessageType.Trace, obj, message));
        }

        public override void Debug(string tag, string message)
        {
            UnityEngine.Debug.Log(GetFormattedMessage(MessageType.Debug, tag, message));
        }

        public override void Debug(object obj, string message)
        {
            UnityEngine.Debug.Log(GetFormattedMessage(MessageType.Debug, obj, message));
        }

        public override void Info(string tag, string message)
        {
            UnityEngine.Debug.Log(GetFormattedMessage(MessageType.Info, tag, message));
        }

        public override void Info(object obj, string message)
        {
            UnityEngine.Debug.Log(GetFormattedMessage(MessageType.Info, obj, message));
        }

        public override void Warning(string tag, string message)
        {
            UnityEngine.Debug.LogWarning(GetFormattedMessage(MessageType.Warning, tag, message));
        }

        public override void Warning(object obj, string message)
        {
            UnityEngine.Debug.LogWarning(GetFormattedMessage(MessageType.Warning, obj, message));
        }

        public override void Error(string tag, string message)
        {
            UnityEngine.Debug.LogError(GetFormattedMessage(MessageType.Error, tag, message));
        }

        public override void Error(object obj, string message)
        {
            UnityEngine.Debug.LogError(GetFormattedMessage(MessageType.Error, obj, message));
        }

        public override void Critical(string tag, string message)
        {
            UnityEngine.Debug.LogError(GetFormattedMessage(MessageType.Critical, tag, message));
        }

        public override void Critical(object obj, string message)
        {
            UnityEngine.Debug.LogError(GetFormattedMessage(MessageType.Critical, obj, message));
        }
    }
}
#endif
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShandyGecko.LogSystem
{
    public class UnityLogger : ILogger
    {
        private readonly Formatter _formatter = new Formatter();
        
        public void Debug(string tag, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(tag, message));
        }

        public void Debug(object obj, string message)
        {
            UnityEngine.Debug.Log(_formatter.Format(obj, message));
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

        public void Exception(string tag, Exception exception)
        {
            UnityEngine.Debug.LogError(_formatter.Format(tag, exception));
            UnityEngine.Debug.LogException(exception);
        }

        public void Exception(object obj, Exception exception)
        {
            UnityEngine.Debug.LogError(_formatter.Format(obj, exception));
            UnityEngine.Debug.LogException(exception);
        }

        public void Assertion(string tag, object assertion)
        {
            UnityEngine.Debug.LogError(_formatter.Format(tag, assertion));
            UnityEngine.Debug.LogAssertion(assertion);
        }

        public void Assertion(object obj, object assertion)
        {
            UnityEngine.Debug.LogError(_formatter.Format(obj, assertion));
            UnityEngine.Debug.LogAssertion(assertion);
        }
    }
}
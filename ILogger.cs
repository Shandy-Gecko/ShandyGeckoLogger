using System;

namespace ShandyGecko.LogSystem
{
    public interface ILogger
    {
        void Debug(string tag, string message);
        void Debug(object obj, string message);
        void Warning(string tag, string message);
        void Warning(object obj, string message);
        void Error(string tag, string message);
        void Error(object obj, string message);
        void Exception(string tag, Exception exception);
        void Exception(object obj, Exception exception);
        void Assertion(string tag, object assertion);
        void Assertion(object obj, object assertion);
    }
}
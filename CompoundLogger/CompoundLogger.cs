using System;
using System.Collections.Generic;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem
{
	public class CompoundLogger : ICompoundLogger
	{
		public IFilter Filter { get; set; }

		private readonly List<ILogger> _loggers = new List<ILogger>();

		public IEnumerable<ILogger> Loggers => _loggers;

		public void SetLoggers(params ILogger[] loggers)
		{
			_loggers.Clear();
			_loggers.AddRange(loggers);
		}

		public void TryAddLogger(ILogger logger)
		{
			if (_loggers.Contains(logger))
			{
				return;
			}
			
			_loggers.Add(logger);
		}
		
		public void TryRemoveLogger(ILogger logger)
		{
			if (_loggers.Contains(logger))
			{
				return;
			}
			
			_loggers.Remove(logger);
		}

		public CompoundLogger()
		{
		}

		public CompoundLogger(params ILogger[] loggers)
		{
			_loggers.AddRange(loggers);
		}

		public void Debug(string tag, string message)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Log, tag, message))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Debug(tag, message);
			}
		}
		
		public void Debug(object obj, string message)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Log, obj, message))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Debug(obj, message);
			}
		}
		
		public void Warning(string tag, string message)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Warning, tag, message))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Warning(tag, message);
			}
		}
		
		public void Warning(object obj, string message)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Warning, obj, message))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Warning(obj, message);
			}
		}
		
		public void Error(string tag, string message)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Error, tag, message))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Error(tag, message);
			}
		}
		
		public void Error(object obj, string message)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Error, obj, message))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Error(obj, message);
			}
		}
		
		public void Exception(string tag, Exception exception)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Exception, tag, exception.ToString()))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Exception(tag, exception);
			}
		}
		
		public void Exception(object obj, Exception exception)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Exception, obj, exception.ToString()))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Exception(obj, exception);
			}
		}
		
		public void Assertion(string tag, object assertion)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Assertion, tag, assertion.ToString()))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Assertion(tag, assertion);
			}
		}
		
		public void Assertion(object obj, object assertion)
		{
			if (Filter != null && !Filter.IsPassed(MessageType.Assertion, obj, assertion.ToString()))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Assertion(obj, assertion);
			}
		}
	}
}
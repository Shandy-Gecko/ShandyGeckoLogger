using System.Collections.Generic;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem
{
	public class CompoundLogger : ICompoundLogger
	{
		private int _loggersCount;
		private IFilter _filter;
		
		private readonly List<ILogger> _loggers = new List<ILogger>();

		private bool IsLoggersListEmpty => _loggersCount == 0;
		
		public IEnumerable<ILogger> Loggers => _loggers;

		public IFilter Filter
		{
			get => _filter ?? (_filter = new FilterAlwaysPass());
			set => _filter = value;
		}

		public void ClearLoggers()
		{
			_loggers.Clear();
			_loggersCount = 0;
		}
		
		public void SetLoggers(params ILogger[] loggers)
		{
			_loggers.AddRange(loggers);
			_loggersCount = loggers.Length;
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
			if (!_loggers.Contains(logger))
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
			SetLoggers(loggers);
		}

		public void Trace(string tag, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Trace, tag))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Trace(tag, message);
			}
		}

		public void Trace(object obj, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Trace, obj))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Trace(obj, message);
			}
		}

		public void Debug(string tag, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Debug, tag))
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
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Debug, obj))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Debug(obj, message);
			}
		}

		public void Info(string tag, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Info, tag))
			{
				return;
			}
			
			foreach (var logger in _loggers)
			{
				logger.Info(tag, message);
			}
		}

		public void Info(object obj, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Info, obj))
			{
				return;
			}
			
			foreach (var logger in _loggers)
			{
				logger.Info(obj, message);
			}
		}

		public void Warning(string tag, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Warning, tag))
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
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Warning, obj))
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
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Error, tag))
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
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Error, obj))
			{
				return;
			}

			foreach (var logger in _loggers)
			{
				logger.Error(obj, message);
			}
		}

		public void Critical(string tag, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Critical, tag))
			{
				return;
			}
			
			foreach (var logger in _loggers)
			{
				logger.Critical(tag, message);
			}
		}

		public void Critical(object obj, string message)
		{
			CheckLoggersCount();
			
			if (!IsFilterPassed(MessageType.Critical, obj))
			{
				return;
			}
			
			foreach (var logger in _loggers)
			{
				logger.Critical(obj, message);
			}
		}

		private bool IsFilterPassed(MessageType msgType, object obj)
		{
			//TODO при переделке на множество фильтров сделать OR или AND по флагу

			return Filter.IsPassed(msgType, obj);
		}
		
		private bool IsFilterPassed(MessageType msgType, string tag)
		{
			//TODO при переделке на множество фильтров сделать OR или AND по флагу
			return Filter.IsPassed(msgType, tag);
		}

		private void CheckLoggersCount()
		{
			if (!IsLoggersListEmpty)
			{
				return;
			}
			
			throw new NoLoggersException();
		}
	}
}
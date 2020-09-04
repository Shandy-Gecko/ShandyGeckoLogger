#if LOG4NET
using System;
using System.Reflection;
using log4net;

namespace ShandyGecko.LogSystem
{
	public class Log4NetLogger : BaseLogger
	{
		private readonly ILog _log4Net = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

		public Log4NetLogger() : this(new DefaultLog4NetConfigurator())
		{
		}

		public Log4NetLogger(ILog4NetConfigurator log4NetConfigurator)
		{
			CheckLogger();
			log4NetConfigurator.Configurate();
		}
		
		public override void Trace(string tag, string message)
		{
			_log4Net.Trace(GetFormattedMessage(MessageType.Trace, tag, message));
		}

		public override void Trace(object obj, string message)
		{
			_log4Net.Trace(GetFormattedMessage(MessageType.Trace, obj, message));
		}

		public override void Debug(string tag, string message)
		{
			_log4Net.Debug(GetFormattedMessage(MessageType.Debug, tag, message));
		}

		public override void Debug(object obj, string message)
		{
			_log4Net.Debug(GetFormattedMessage(MessageType.Debug, obj, message));
		}

		public override void Info(string tag, string message)
		{
			_log4Net.Info(GetFormattedMessage(MessageType.Info, tag, message));
		}

		public override void Info(object obj, string message)
		{
			_log4Net.Info(GetFormattedMessage(MessageType.Info, obj, message));
		}

		public override void Warning(string tag, string message)
		{
			_log4Net.Warn(GetFormattedMessage(MessageType.Warning, tag, message));
		}

		public override void Warning(object obj, string message)
		{
			_log4Net.Warn(GetFormattedMessage(MessageType.Warning, obj, message));
		}

		public override void Error(string tag, string message)
		{
			_log4Net.Error(GetFormattedMessage(MessageType.Error, tag, message));
		}

		public override void Error(object obj, string message)
		{
			_log4Net.Error(GetFormattedMessage(MessageType.Error, obj, message));
		}

		public override void Critical(string tag, string message)
		{
			_log4Net.Critical(GetFormattedMessage(MessageType.Critical, tag, message));
		}

		public override void Critical(object obj, string message)
		{
			_log4Net.Critical(GetFormattedMessage(MessageType.Critical, obj, message));
		}

		private void CheckLogger()
		{
			if (_log4Net != null)
			{
				return;
			}
			
			throw new Exception("Can't get Log4Net!");
		}
	}
}
#endif
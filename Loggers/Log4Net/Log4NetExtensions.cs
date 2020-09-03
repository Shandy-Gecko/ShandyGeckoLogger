#if LOG4NET
using System;
using log4net;

namespace ShandyGecko.LogSystem
{
	public static class Log4NetExtensions
	{
		public static void Trace(this ILog log, string message, Exception exception)
		{
			log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType, 
				log4net.Core.Level.Trace, message, exception);
		}

		public static void Trace(this ILog log, string message)
		{
			log.Trace(message, null);
		}
	}
}
#endif
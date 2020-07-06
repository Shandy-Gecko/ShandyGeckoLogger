using System.Collections.Generic;

namespace ShandyGecko.LogSystem
{
	public interface ICompoundLogger : ILogger
	{
		IEnumerable<ILogger> Loggers { get; }

		void SetLoggers(params ILogger[] loggers);

		void TryAddLogger(ILogger logger);

		void TryRemoveLogger(ILogger logger);
	}
}
using System.Collections.Generic;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem
{
	public interface ICompoundLogger : ILogger
	{
		IFilter Filter { get; set; }

		IEnumerable<ILogger> Loggers { get; }

		void ClearLoggers();
		void SetLoggers(params ILogger[] loggers);

		void TryAddLogger(ILogger logger);
		void TryRemoveLogger(ILogger logger);
	}
}
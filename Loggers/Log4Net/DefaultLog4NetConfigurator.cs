#if LOG4NET
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace ShandyGecko.LogSystem
{
	public class DefaultLog4NetConfigurator : ILog4NetConfigurator
	{
		public string ConfigName => "log4net.config";
		
		public void Configurate()
		{
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo(ConfigName));
		}
	}
}
#endif
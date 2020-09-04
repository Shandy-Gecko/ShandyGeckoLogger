#if LOG4NET
using System;
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
			var configFile = new FileInfo(ConfigName);

			if (!configFile.Exists)
			{
				Console.WriteLine(
					$"There is no log4net config file with name {ConfigName} at path {Directory.GetCurrentDirectory()}");
				return;
			}
			
			XmlConfigurator.Configure(logRepository, configFile);
			Console.WriteLine($"Load log4net config file {ConfigName} at path {configFile.FullName}");
		}
	}
}
#endif
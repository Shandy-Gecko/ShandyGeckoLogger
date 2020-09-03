#if LOG4NET
namespace ShandyGecko.LogSystem
{
	public interface ILog4NetConfigurator
	{
		string ConfigName { get; }
		void Configurate();
	}
}
#endif
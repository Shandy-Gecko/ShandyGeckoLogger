namespace ShandyGecko.LogSystem
{
	public interface IFormattedLogger
	{
		IFormatter Formatter { get; set; }
	}
}
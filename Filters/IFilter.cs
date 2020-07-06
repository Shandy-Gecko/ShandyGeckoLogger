namespace ShandyGecko.LogSystem.Filters
{
	public interface IFilter
	{
		bool IsPassed(MessageType messageType, string tag, string msg);
		bool IsPassed(MessageType messageType, object obj, string msg);
	}
}
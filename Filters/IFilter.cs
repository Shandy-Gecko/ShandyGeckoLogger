namespace ShandyGecko.LogSystem.Filters
{
	public interface IFilter
	{
		bool IsPassed(MessageType messageType, string tag);
		bool IsPassed(MessageType messageType, object obj);
	}
}
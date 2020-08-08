namespace ShandyGecko.LogSystem.Filters
{
	public class FilterAlwaysPass : IFilter
	{
		public bool IsPassed(MessageType messageType, string tag)
		{
			return true;
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return true;
		}
	}
}
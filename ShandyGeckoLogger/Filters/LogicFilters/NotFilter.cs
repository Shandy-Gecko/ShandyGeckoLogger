namespace ShandyGecko.LogSystem.Filters
{
	public class NotFilter : INotFilter
	{
		public IFilter InnerFilter { get; }

		public NotFilter(IFilter innerFilter)
		{
			InnerFilter = innerFilter;
		}
		
		public bool IsPassed(MessageType messageType, string tag)
		{
			return !InnerFilter.IsPassed(messageType, tag);
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return !InnerFilter.IsPassed(messageType, obj);
		}
	}
}
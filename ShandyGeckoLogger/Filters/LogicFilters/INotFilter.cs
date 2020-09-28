namespace ShandyGecko.LogSystem.Filters
{
	public interface INotFilter : IFilter
	{
		IFilter InnerFilter { get; }
	}
}
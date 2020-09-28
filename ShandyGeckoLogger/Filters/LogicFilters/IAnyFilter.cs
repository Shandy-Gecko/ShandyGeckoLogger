using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface IAnyFilter : IFilter
	{
		IEnumerable<IFilter> InnerFilters { get; }
	}
}
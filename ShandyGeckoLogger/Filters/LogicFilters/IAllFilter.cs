using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface IAllFilter : IFilter
	{
		IEnumerable<IFilter> InnerFilters { get; }
	}
}
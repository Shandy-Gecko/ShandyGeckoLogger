using System.Collections.Generic;
using System.Linq;

namespace ShandyGecko.LogSystem.Filters
{
	public class AllFilter : IAllFilter
	{
		private List<IFilter> _innerFilters;

		public IEnumerable<IFilter> InnerFilters => _innerFilters;

		public AllFilter(params IFilter[] innerFilters)
		{
			_innerFilters = new List<IFilter>(innerFilters);
		}
		
		public bool IsPassed(MessageType messageType, string tag)
		{
			return _innerFilters.All(x => x.IsPassed(messageType, tag));
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return _innerFilters.All(x => x.IsPassed(messageType, obj));
		}
	}
}
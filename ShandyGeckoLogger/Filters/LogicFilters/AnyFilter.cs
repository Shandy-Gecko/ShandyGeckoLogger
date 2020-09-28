using System.Collections.Generic;
using System.Linq;

namespace ShandyGecko.LogSystem.Filters
{
	public class AnyFilter : IAnyFilter
	{
		private List<IFilter> _innerFilters;

		public IEnumerable<IFilter> InnerFilters => _innerFilters;
		
		public AnyFilter(params IFilter[] innerFilters)
		{
			_innerFilters = new List<IFilter>(innerFilters);
		}
		
		public bool IsPassed(MessageType messageType, string tag)
		{
			return _innerFilters.Any(x => x.IsPassed(messageType, tag));
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return _innerFilters.Any(x => x.IsPassed(messageType, obj));
		}
	}
}
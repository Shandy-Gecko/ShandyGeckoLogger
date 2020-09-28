using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface ITagFilter : IFilter
	{
		IEnumerable<string> Tags { get; }

		void AddTag(string tag);
		void RemoveTag(string tag);
	}
}
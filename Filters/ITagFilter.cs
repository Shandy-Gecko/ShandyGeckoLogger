using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface ITagFilter
	{
		IEnumerable<string> Tags { get; }

		void AddTag(string tag);
		void RemoveTag(string tag);
	}
}
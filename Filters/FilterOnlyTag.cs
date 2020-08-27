using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public class FilterOnlyTag : IFilter, ITagFilter
	{
		private readonly HashSet<string> _tags = new HashSet<string>();

		public IEnumerable<string> Tags => _tags;

		public void AddTag(string tag)
		{
			if (_tags.Contains(tag))
			{
				return;
			}

			_tags.Add(tag);
		}

		public void RemoveTag(string tag)
		{
			if (_tags.Contains(tag))
			{
				return;
			}

			_tags.Remove(tag);
		}
		
		public bool IsPassed(MessageType messageType, string tag)
		{
			return _tags.Contains(tag);
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return false;
		}
	}
}
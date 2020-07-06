using System.Collections.Generic;

namespace LowPolyShooter.LogSystem.Filters
{
	public class FilterOnlyTag : IFilter
	{
		private readonly HashSet<string> _tags = new HashSet<string>();

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
		
		public bool IsPassed(MessageType messageType, string tag, string msg)
		{
			return _tags.Contains(tag);
		}

		public bool IsPassed(MessageType messageType, object obj, string msg)
		{
			return false;
		}
	}
}
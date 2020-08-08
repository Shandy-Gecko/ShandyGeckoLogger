using System;
using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public class FilterTagOrType : IFilter, ITagFilter, ITypeFilter
	{
		private readonly HashSet<string> _tags = new HashSet<string>();
		private readonly HashSet<Type> _types = new HashSet<Type>();

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
		
		public void AddType(Type type)
		{
			if (_types.Contains(type))
			{
				return;
			}

			_types.Add(type);
		}
		
		public void RemoveType(Type type)
		{
			if (_types.Contains(type))
			{
				return;
			}

			_types.Remove(type);
		}

		public bool IsPassed(MessageType messageType, string tag)
		{
			return _tags.Contains(tag);
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return _types.Contains(obj.GetType());
		}
	}
}
using System;
using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public class FilterOnlyType : ITypeFilter
	{
		private readonly HashSet<Type> _types = new HashSet<Type>();

		public IEnumerable<Type> Types => _types;

		public FilterOnlyType()
		{
		}

		public FilterOnlyType(params Type[] types)
		{
			foreach (var type in types)
			{
				_types.Add(type);
			}
		}
		
		public bool IsPassed(MessageType messageType, string tag)
		{
			return false;
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return _types.Contains(obj.GetType());
		}

		public void AddType(Type type)
		{
			if (type == null)
			{
				return;
			}
			
			if (_types.Contains(type))
			{
				return;
			}

			_types.Add(type);
		}

		public void RemoveType(Type type)
		{
			if (type == null)
			{
				return;
			}
			
			if (!_types.Contains(type))
			{
				return;
			}

			_types.Remove(type);
		}
	}
}
using System;
using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public class FilterOnlyType : IFilter, ITypeFilter
	{
		private readonly HashSet<Type> _types = new HashSet<Type>();
		
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
	}
}
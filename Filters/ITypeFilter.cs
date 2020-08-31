using System;
using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface ITypeFilter
	{
		IEnumerable<Type> Types { get; }
		
		void AddType(Type type);
		void RemoveType(Type type);
	}
}
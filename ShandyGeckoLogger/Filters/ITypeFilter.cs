using System;
using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface ITypeFilter : IFilter
	{
		IEnumerable<Type> Types { get; }
		
		void AddType(Type type);
		void RemoveType(Type type);
	}
}
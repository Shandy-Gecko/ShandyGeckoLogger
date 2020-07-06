using System;

namespace ShandyGecko.LogSystem.Filters
{
	public interface ITypeFilter
	{
		void AddType(Type type);
		void RemoveType(Type type);
	}
}
using System;

namespace LowPolyShooter.LogSystem.Filters
{
	public interface ITypeFilter
	{
		void AddType(Type type);
		void RemoveType(Type type);
	}
}
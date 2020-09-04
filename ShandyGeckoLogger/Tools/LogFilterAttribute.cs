using System;

namespace ShandyGecko.LogSystem
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field)]
	public class LogFilterAttribute : Attribute
	{
	}
}
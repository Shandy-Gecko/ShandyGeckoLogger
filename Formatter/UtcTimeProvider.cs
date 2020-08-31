using System;
using System.Globalization;

namespace ShandyGecko.LogSystem
{
	public class UtcTimeProvider : IFormatterValueProvider
	{
		public const string ProviderName = "UtcTime";
		public string Name => ProviderName;
		public string GetValue()
		{
			return DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
		}
	}
}
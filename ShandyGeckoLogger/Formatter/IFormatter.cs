using System.Collections.Generic;

namespace ShandyGecko.LogSystem
{
	public interface IFormatter
	{
		string Format(MessageType type, object obj, string message);
		string Format(MessageType type, string tag, string message);

		void AddValueProvider(IFormatterValueProvider valueProvider);
		void RemoveValueProvider(IFormatterValueProvider valueProvider);
		IEnumerable<IFormatterValueProvider> ValueProviders { get; }
	}
}
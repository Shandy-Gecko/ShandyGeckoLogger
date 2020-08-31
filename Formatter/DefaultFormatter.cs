using System.Collections.Generic;
using System.Text;

namespace ShandyGecko.LogSystem
{
	public class DefaultFormatter : IFormatter
	{
		private readonly List<IFormatterValueProvider> _valueProviders = new List<IFormatterValueProvider>();
		private readonly StringBuilder _stringBuilder = new StringBuilder();

		public string Format(MessageType type, object obj, string message)
		{
			return $"[{type}]-{obj.ToLogString()}: {message}\n{GetFormatterValues()}";
		}
		
		public string Format(MessageType type, string tag, string message)
		{
			return $"[{type}]-[{tag}]: {message}\n{GetFormatterValues()}";
		}

		public void AddValueProvider(IFormatterValueProvider valueProvider)
		{
			if (!CanModifyValueProvidersCollection(valueProvider))
			{
				return;
			}
			
			_valueProviders.Add(valueProvider);
		}

		public void RemoveValueProvider(IFormatterValueProvider valueProvider)
		{
			if (!CanModifyValueProvidersCollection(valueProvider))
			{
				return;
			}

			_valueProviders.Remove(valueProvider);
		}

		public IEnumerable<IFormatterValueProvider> ValueProviders => _valueProviders;

		private string GetFormatterValues()
		{
			if (_valueProviders?.Count == 0)
			{
				return string.Empty;
			}

			_stringBuilder.Clear();

			foreach (var valueProvider in _valueProviders)
			{
				_stringBuilder.AppendLine($"[{valueProvider.Name}] - {valueProvider.GetValue()}");
			}

			return _stringBuilder.ToString();
		}

		private bool CanModifyValueProvidersCollection(IFormatterValueProvider valueProvider)
		{
			return valueProvider != null && !_valueProviders.Contains(valueProvider);
		}
	}
}
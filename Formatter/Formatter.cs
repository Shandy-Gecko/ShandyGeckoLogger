using System;
using System.Collections.Generic;
using System.Text;

namespace ShandyGecko.LogSystem
{
	public class Formatter
	{
		private static readonly List<IFormatterValueProvider> ValueProviders;
		private static readonly StringBuilder StringBuilder;
		
		static Formatter()
		{
			StringBuilder = new StringBuilder();
			
			ValueProviders = new List<IFormatterValueProvider>
			{
			};
		}
		
		public string Format(MessageType type, object obj, string message)
		{
			return $"[{type}]-{obj.ToLogString()}: {message}\n{GetFormatterValues()}";
		}
		
		public string Format(MessageType type, string tag, string message)
		{
			return $"[{type}]-[{tag}]: {message}\n{GetFormatterValues()}";
		}
		
		public string Format(object obj, string message)
		{
			return $"[{obj.ToLogString()}: {message}\n{GetFormatterValues()}";
		}
		
		public string Format(string tag, string message)
		{
			return $"[{tag}]: {message}\n{GetFormatterValues()}";
		}

		private string GetFormatterValues()
		{
			if (ValueProviders?.Count == 0)
			{
				return string.Empty;
			}

			StringBuilder.Clear();

			foreach (var valueProvider in ValueProviders)
			{
				StringBuilder.AppendLine(valueProvider.GetValue());
			}

			return StringBuilder.ToString();
		}
	}
}
using System.Diagnostics;
using System.Text;

namespace ShandyGecko.LogSystem
{
	public class StackTraceProvider : IFormatterValueProvider
	{
		public string Name => "StackTraceProvider";
		
		public string GetValue()
		{
			var stack = new StackTrace();
			var frames = stack.GetFrames();
			if (frames == null)
			{
				return string.Empty;
			}

			var builder = new StringBuilder();
			foreach (var frame in frames)
			{
				var declaringType = frame.GetMethod().DeclaringType;
				if (declaringType == null ||
				    declaringType == typeof(Log) ||
				    declaringType.BaseType == typeof(IFormatter))
				{
					continue;
				}

				builder.AppendFormat("{0}.{1} line {2}",
					frame.GetMethod().DeclaringType?.FullName,
					frame.GetMethod().Name,
					frame.GetFileLineNumber()).AppendLine();
			}

			return builder.ToString();
		}
	}
}
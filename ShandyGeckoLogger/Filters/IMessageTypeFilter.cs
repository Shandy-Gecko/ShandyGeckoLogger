using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public interface IMessageTypeFilter : IFilter
	{
		IEnumerable<MessageType> Types { get; }
		
		void AddMessageType(MessageType type);
		void RemoveMessageType(MessageType type);
	}
}
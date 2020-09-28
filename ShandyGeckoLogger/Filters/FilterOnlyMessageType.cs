using System.Collections.Generic;

namespace ShandyGecko.LogSystem.Filters
{
	public class FilterOnlyMessageType : IMessageTypeFilter
	{
		private readonly HashSet<MessageType> _messageTypes = new HashSet<MessageType>();

		public IEnumerable<MessageType> Types => _messageTypes;

		public FilterOnlyMessageType(params MessageType[] messageTypes)
		{
			foreach (var messageType in messageTypes)
			{
				_messageTypes.Add(messageType);
			}
		}
		
		public bool IsPassed(MessageType messageType, string tag)
		{
			return _messageTypes.Contains(messageType);
		}

		public bool IsPassed(MessageType messageType, object obj)
		{
			return _messageTypes.Contains(messageType);
		}
		
		public void AddMessageType(MessageType type)
		{
			if (_messageTypes.Contains(type))
			{
				return;
			}

			_messageTypes.Add(type);
		}

		public void RemoveMessageType(MessageType type)
		{
			if (!_messageTypes.Contains(type))
			{
				return;
			}

			_messageTypes.Remove(type);
		}
	}
}
using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
	public class MessageTypeFilterTests
	{
		private const MessageType AllowedType = MessageType.Info;
		
		[TestCase(AllowedType, true)]
		[TestCase(MessageType.Trace, false)]
		[TestCase(MessageType.Debug, false)]
		[TestCase(MessageType.Warning, false)]
		[TestCase(MessageType.Error, false)]
		[TestCase(MessageType.Critical, false)]
		public void IsPassedTagTest(MessageType messageType, bool expected)
		{
			var onlyMessageTypeFilter = new FilterOnlyMessageType(AllowedType);

			onlyMessageTypeFilter.AddMessageType(AllowedType);
			
			var actual = onlyMessageTypeFilter.IsPassed(messageType, "Test");
			
			Assert.AreEqual(expected, actual);
		}
		
		[TestCase(AllowedType, true)]
		[TestCase(MessageType.Trace, false)]
		[TestCase(MessageType.Debug, false)]
		[TestCase(MessageType.Warning, false)]
		[TestCase(MessageType.Error, false)]
		[TestCase(MessageType.Critical, false)]
		public void IsPassedTypeTest(MessageType messageType, bool expected)
		{
			var onlyMessageTypeFilter = new FilterOnlyMessageType(AllowedType);

			onlyMessageTypeFilter.AddMessageType(AllowedType);
			
			var actual = onlyMessageTypeFilter.IsPassed(messageType, this);
			
			Assert.AreEqual(expected, actual);
		}
	}
}
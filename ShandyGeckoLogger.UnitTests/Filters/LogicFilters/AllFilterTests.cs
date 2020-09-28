using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
	public class AllFilterTests
	{
		private const string TestTag1 = "Test1";
		private const string TestTag2 = "Test2";
		private const MessageType AllowedMessageType = MessageType.Critical;
		
		private AllFilter _allFilter;
        
		[SetUp]
		public void OnSetUp()
		{
			var filter1 = new FilterOnlyTag(TestTag1);
			var filter2 = new FilterOnlyMessageType(AllowedMessageType);

			_allFilter = new AllFilter(filter1, filter2);
		}

		[TearDown]
		public void OnTearDown()
		{
			_allFilter = null;
		}

		[TestCase(AllowedMessageType, TestTag1, true)]
		[TestCase(AllowedMessageType, TestTag2, false)]
		[TestCase(MessageType.Info, TestTag1, false)]
		[TestCase(MessageType.Debug, TestTag1, false)]
		[TestCase(MessageType.Trace, TestTag1, false)]
		[TestCase(MessageType.Warning, TestTag1, false)]
		[TestCase(MessageType.Error, TestTag1, false)]
		[TestCase(MessageType.Critical, TestTag1, false)]
		public void IsPassedTagAndMessageTypeTest(MessageType messageType, string tag, bool expected)
		{
			var actual = _allFilter.IsPassed(messageType, tag);
		}
	}
}
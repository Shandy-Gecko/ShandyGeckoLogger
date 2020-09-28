using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
	public class NotFilterTests
	{
		private NotFilter _notFilter;
        
		[SetUp]
		public void OnSetUp()
		{
			_notFilter = new NotFilter(new FilterAlwaysPass());
		}

		[TearDown]
		public void OnTearDown()
		{
			_notFilter = null;
		}

		[TestCase(MessageType.Trace)]
		[TestCase(MessageType.Debug)]
		[TestCase(MessageType.Info)]
		[TestCase(MessageType.Warning)]
		[TestCase(MessageType.Error)]
		[TestCase(MessageType.Critical)]
		public void IsTagPassedTest(MessageType messageType)
		{
			Assert.IsFalse(_notFilter.IsPassed(messageType, "TEST"));
		}
        
		[TestCase(MessageType.Trace)]
		[TestCase(MessageType.Debug)]
		[TestCase(MessageType.Info)]
		[TestCase(MessageType.Warning)]
		[TestCase(MessageType.Error)]
		[TestCase(MessageType.Critical)]
		public void IsTypePassedTest(MessageType messageType)
		{
			Assert.IsFalse(_notFilter.IsPassed(messageType, new object()));
		}
	}
}
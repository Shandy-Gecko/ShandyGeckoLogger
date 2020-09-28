using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
	public class AnyFilterTests
	{
		private const string TestTag1 = "Test1";
		private const string TestTag2 = "Test2";
		
		private AnyFilter _anyFilter;
        
		[SetUp]
		public void OnSetUp()
		{
			var filter1 = new FilterOnlyTag(TestTag1);
			var filter2 = new FilterOnlyTag(TestTag2);
			
			_anyFilter = new AnyFilter(filter1, filter2);
		}

		[TearDown]
		public void OnTearDown()
		{
			_anyFilter = null;
		}

		[Test]
		public void TestFilter()
		{
			Assert.IsTrue(_anyFilter.IsPassed(MessageType.Info, TestTag1));
			Assert.IsTrue(_anyFilter.IsPassed(MessageType.Info, TestTag2));
		}
	}
}
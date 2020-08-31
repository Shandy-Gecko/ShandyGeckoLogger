using System.Linq;
using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
	public class FilterOnlyTagTests
	{
		private const string TestTag = "Test";
		
		private FilterOnlyTag _filterOnlyTag;

		[SetUp]
		public void OnSetUp()
		{
			_filterOnlyTag = new FilterOnlyTag();
		}

		[TearDown]
		public void OnTearDown()
		{
			_filterOnlyTag = null;
		}

		[TestCase(TestTag, true)]
		[TestCase(null, false)]
		[TestCase("", false)]
		public void AddTagTest(string tag, bool addExpected)
		{
			_filterOnlyTag.AddTag(tag);
			
			Assert.AreEqual(addExpected, _filterOnlyTag.Tags.Contains(tag));
		}

		[Test]
		public void DoubleAddTagTest()
		{
			_filterOnlyTag.AddTag(TestTag);
			_filterOnlyTag.AddTag(TestTag);
			
			Assert.AreEqual(1, _filterOnlyTag.Tags.Count());
		}
		
		[Test]
		public void RemoveTagTest()
		{
			_filterOnlyTag.AddTag(TestTag);
			Assert.IsTrue(_filterOnlyTag.Tags.Contains(TestTag));
			
			_filterOnlyTag.RemoveTag(TestTag);
			Assert.IsFalse(_filterOnlyTag.Tags.Contains(TestTag));
		}

		[TestCase(MessageType.Trace, true, true)]
		[TestCase(MessageType.Debug, true, true)]
		[TestCase(MessageType.Info, true, true)]
		[TestCase(MessageType.Debug, true, true)]
		[TestCase(MessageType.Warning, true, true)]
		[TestCase(MessageType.Error, true, true)]
		[TestCase(MessageType.Critical, true, true)]
		[TestCase(MessageType.Trace, false, false)]
		[TestCase(MessageType.Debug, false, false)]
		[TestCase(MessageType.Info, false, false)]
		[TestCase(MessageType.Debug, false, false)]
		[TestCase(MessageType.Warning, false, false)]
		[TestCase(MessageType.Error, false, false)]
		[TestCase(MessageType.Critical, false, false)]
		public void IsTagPassedTest(MessageType messageType, bool isTagAdded, bool expected)
		{
			if (isTagAdded)
			{
				_filterOnlyTag.AddTag(TestTag);
			}
			
			var actual = _filterOnlyTag.IsPassed(messageType, TestTag);
			
			Assert.AreEqual(expected, actual);
		}
		
		[TestCase(MessageType.Trace)]
		[TestCase(MessageType.Debug)]
		[TestCase(MessageType.Info)]
		[TestCase(MessageType.Warning)]
		[TestCase(MessageType.Error)]
		[TestCase(MessageType.Critical)]
		public void IsTypePassedTest(MessageType messageType)
		{
			Assert.False(_filterOnlyTag.IsPassed(messageType, new object()));
		}
	}
}
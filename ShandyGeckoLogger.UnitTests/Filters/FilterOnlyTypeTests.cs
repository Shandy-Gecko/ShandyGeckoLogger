using System.Linq;
using NUnit.Framework;
using ShandyGecko.LogSystem.Filters;

namespace ShandyGecko.LogSystem.Tests
{
	public class FilterOnlyTypeTests
	{
		private FilterOnlyType _filterOnlyType;
		
		private readonly object _testObj = new object();

		[SetUp]
		public void OnSetUp()
		{
			_filterOnlyType = new FilterOnlyType();
		}

		[TearDown]
		public void OnTearDown()
		{
			_filterOnlyType = null;
		}

		[Test]
		public void AddTypeTest()
		{
			_filterOnlyType.AddType(_testObj.GetType());
			
			Assert.Contains(_testObj.GetType(), _filterOnlyType.Types.ToList());
		}

		[Test]
		public void AddNullTypeTest()
		{
			_filterOnlyType.AddType(null);
			Assert.IsEmpty(_filterOnlyType.Types.ToList());
		}
		
		[Test]
		public void RemoveTypeTest()
		{
			_filterOnlyType.AddType(_testObj.GetType());
			Assert.Contains(_testObj.GetType(), _filterOnlyType.Types.ToList());
			
			_filterOnlyType.RemoveType(_testObj.GetType());
			Assert.IsEmpty(_filterOnlyType.Types.ToList());
		}

		[Test]
		public void RemoveNullTypeTest()
		{
			Assert.IsEmpty(_filterOnlyType.Types.ToList());
			
			_filterOnlyType.RemoveType(null);
			Assert.IsEmpty(_filterOnlyType.Types.ToList());
		}

		[Test]
		public void DoubleAddTest()
		{
			_filterOnlyType.AddType(_testObj.GetType());
			_filterOnlyType.AddType(_testObj.GetType());
			
			Assert.AreEqual(1, _filterOnlyType.Types.Count());
		}

		[Test]
		public void DoubleRemoveTest()
		{
			_filterOnlyType.RemoveType(_testObj.GetType());
			_filterOnlyType.RemoveType(_testObj.GetType());
			
			Assert.IsEmpty(_filterOnlyType.Types.ToList());
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
		public void IsTypePassedTest(MessageType messageType, bool isTypeAdded, bool expected)
		{
			if (isTypeAdded)
			{
				_filterOnlyType.AddType(_testObj.GetType());
			}
			
			var actual = _filterOnlyType.IsPassed(messageType, _testObj);
			
			Assert.AreEqual(expected, actual);
		}

		[TestCase(MessageType.Trace)]
		[TestCase(MessageType.Debug)]
		[TestCase(MessageType.Info)]
		[TestCase(MessageType.Warning)]
		[TestCase(MessageType.Error)]
		[TestCase(MessageType.Critical)]
		public void IsTagPassedTest(MessageType messageType)
		{
			Assert.False(_filterOnlyType.IsPassed(messageType, "TEST"));
		}
	}
}
using System;
using System.Globalization;
using NUnit.Framework;

namespace ShandyGecko.LogSystem.Tests.Formatters
{
	public class UtcTimeProviderTests
	{
		private IFormatterValueProvider _utcTimeProvider;
		
		[SetUp]
		public void OnSetUp()
		{
			_utcTimeProvider = new UtcTimeProvider();
		}

		[Test]
		public void NameTest()
		{
			Assert.AreEqual(UtcTimeProvider.ProviderName, _utcTimeProvider.Name);
		}

		[Test]
		public void GetValueTest()
		{
			Assert.AreEqual(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), _utcTimeProvider.GetValue());
		}
	}
}
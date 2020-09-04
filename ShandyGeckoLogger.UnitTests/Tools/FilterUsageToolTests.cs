using System.Linq;
using NUnit.Framework;

namespace ShandyGecko.LogSystem.Tests.Tools
{
	public class FilterUsageToolTests
	{
		[Test]
		public void LoadAllFilterTypesTest()
		{
			var filterTypes = FilterUsageTool.LoadAllFilterTypes();

			Assert.Contains(typeof(TestFilterClass), filterTypes.ToList());
		}
		
		[Test]
		public void LoadAllFilterTagsTest()
		{
			var filterTags = FilterUsageTool.LoadAllFilterTags();

			Assert.Contains(TestFilterClass.TestTag, filterTags.ToList());
		}
	}
}
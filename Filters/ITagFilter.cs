namespace ShandyGecko.LogSystem.Filters
{
	public interface ITagFilter
	{
		void AddTag(string tag);
		void RemoveTag(string tag);
	}
}
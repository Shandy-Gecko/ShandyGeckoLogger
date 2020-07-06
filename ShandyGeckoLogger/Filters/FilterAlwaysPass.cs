namespace LowPolyShooter.LogSystem.Filters
{
	public class FilterAlwaysPass : IFilter
	{
		public bool IsPassed(MessageType messageType, string tag, string msg)
		{
			return true;
		}

		public bool IsPassed(MessageType messageType, object obj, string msg)
		{
			return true;
		}
	}
}
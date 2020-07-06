namespace LowPolyShooter.LogSystem
{
	public static class ObjectExtension
	{
		public static string ToLogString(this object obj)
		{
			return $"[{obj.GetType()}]";
		} 
	}
}
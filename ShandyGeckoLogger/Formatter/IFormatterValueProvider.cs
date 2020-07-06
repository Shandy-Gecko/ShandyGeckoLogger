namespace LowPolyShooter.LogSystem
{
	public interface IFormatterValueProvider
	{
		string Name { get; }
		string GetValue();
	}
}
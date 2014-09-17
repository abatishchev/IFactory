namespace Factory
{
	public interface IFactory<out T>
	{
		T Create();
	}

	public interface IFactory<out T, in TParam>
	{
		T Create(TParam param);
	}
}
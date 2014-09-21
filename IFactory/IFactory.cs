namespace Factory
{
	public interface IFactory<out T>
	{
		T Create();
	}

	public interface IFactory<out T, in TArg1>
	{
		T Create(TArg1 param);
	}

	public interface IFactory<out T, in TArg1, in TArg2>
	{
		T Create(TArg1 param1, TArg2 param2);
	}
}
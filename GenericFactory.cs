namespace Factory
{
	public class GenericFactory<T> : IFactory<T>
		where T : new()
	{
		public T Create()
		{
			return new T();
		}
	}
}
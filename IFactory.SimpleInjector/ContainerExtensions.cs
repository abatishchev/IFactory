using Factory;
using SimpleInjector;

namespace Factory.SimpleInjector
{
	public static class ContainerExtensions
	{
		public static void RegisterFactory<T, TFactory>(this Container container)
			where T : class
			where TFactory : class, IFactory<T>
		{
			container.Register<IFactory<T>, TFactory>(Lifestyle.Singleton);
			container.Register(() => container.GetInstance<TFactory>().Create());
		}

		public static void RegisterFactory<T, U, TFactory>(this Container container)
			where TFactory : class, IFactory<T, U>
		{
			container.Register<IFactory<T, U>, TFactory>(Lifestyle.Singleton);
		}

		public static void RegisterFactory<T, U1, U2, TFactory>(this Container container)
			where TFactory : class, IFactory<T, U1, U2>
		{
			container.Register<IFactory<T, U1, U2>, TFactory>(Lifestyle.Singleton);
		}
	}
}
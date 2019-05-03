using SimpleInjector;

namespace Factory.SimpleInjector
{
	public static class ContainerExtensions
	{
		public static void RegisterFactory<T, TFactory>(this Container container, Lifestyle instanceLifestyle = null, Lifestyle factoryLifestyle = null)
			where T : class
			where TFactory : class, IFactory<T>
		{
			container.Register<IFactory<T>, TFactory>(factoryLifestyle ?? Lifestyle.Singleton);
			container.Register(() => container.GetInstance<TFactory>().Create(), instanceLifestyle ?? Lifestyle.Transient);
		}

		public static void RegisterFactory<T, U, TFactory>(this Container container, Lifestyle factoryLifestyle = null)
			where TFactory : class, IFactory<T, U>
		{
			container.Register<IFactory<T, U>, TFactory>(factoryLifestyle ?? Lifestyle.Singleton);
		}

		public static void RegisterFactory<T, U1, U2, TFactory>(this Container container, Lifestyle factoryLifestyle = null)
			where TFactory : class, IFactory<T, U1, U2>
		{
			container.Register<IFactory<T, U1, U2>, TFactory>(factoryLifestyle ?? Lifestyle.Singleton);
		}
	}
}
IFactory
===

Set of interfaces for the Abstract Factory pattern such as IFactory&lt;T>

Downloads
===

Available on NuGet:

- [IFactory](https://www.nuget.org/packages/IFactory/)
- [IFactory.SimpleInjector](https://www.nuget.org/packages/IFactory.SimpleInjector/)

Samples
===

Rather than using `Func<T>` that you can't really easily to mock-up or register into a dependency injection container, use `IFactory<T>` instead:

```csharp
public class OrderRepository
{
    public OrderRepository(IFactory<DbContext> dbContextFactory)
    {
      var dbContext = dbContextFactory.Create();
    }
}
```

To simplify such registration and increase code reuse, use the following extension method. The one provided is for [SimpleInjector](https://github.com/simpleinjector/SimpleInjector/):

```csharp
using IFactory.SimpleInjector;

internal static class ContainerConfig
{
  public void RegisterTypes(Container container)
  {
    container.RegisterFactory<DbContext, DbContextFactory>();
  }
}

public class DbContextFactory : IFactory<DbContext>
{
  public DbContext Create()
  {
    return new DbContext("connection string from configuration or another dependency");
  }
}

```

So now instead of injecting `IFactory<T>` and calling `Create()` every time manually, you can inject just `T` itself:

```csharp
public class OrderRepository
{
    public OrderRepository(DbContext dbContext)
    {
      // DbContextFactory.Create() was called when `OrderRepository` was instantiated
    }
}
```

Legal
===
Licensed under the  [MIT License](https://github.com/abatishchev/IFactory/blob/master/LICENSE)

IFactory
===

Set of interfaces for the Abstract Factory pattern such as `IFactory<T>`.

Downloads
===

Available on NuGet:

[![IFactory](https://img.shields.io/nuget/v/IFactory.svg)](https://www.nuget.org/packages/IFactory)
[![IFactory.SimpleInjector](https://img.shields.io/nuget/vpre/IFactory.SimpleInjector.svg)](https://www.nuget.org/packages/IFactory.SimpleInjector)
[![Build Status](https://abatishchev.visualstudio.com/OpenSource/_apis/build/status/abatishchev.IFactory?branchName=master)](https://abatishchev.visualstudio.com/OpenSource/_build/latest?definitionId=8&branchName=master)
[![Release status](https://abatishchev.vsrm.visualstudio.com/_apis/public/Release/badge/b7fc2610-91d5-4968-814c-97a9d76b03c4/3/3)](https://abatishchev.visualstudio.com/OpenSource/_release?definitionId=3&_a=releases)

Samples
===

Rather than using `Func<T>` that you can't really easily to mock-up or register into a dependency injection container, use `IFactory<T>` instead:

```c#
public class OrderRepository
{
    public OrderRepository(IFactory<DbContext> dbContextFactory)
    {
      var dbContext = dbContextFactory.Create();
    }
}
```

To simplify such registration and increase code reuse, use the following extension method. The one provided is for [SimpleInjector](https://github.com/simpleinjector/SimpleInjector/):

```c#
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

```c#
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

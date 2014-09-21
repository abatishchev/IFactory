using System;

namespace Factory
{
	public class DelegateFactory<T> : IFactory<T>
	{
		private readonly Func<T> _func;

		public DelegateFactory(Func<T> func)
		{
			_func = func;
		}

		public T Create()
		{
			return _func();
		}
	}

	public class DelegateFactory<T, TArg1> : IFactory<T, TArg1>
	{
		private readonly Func<TArg1, T> _func;

		public DelegateFactory(Func<TArg1, T> func)
		{
			_func = func;
		}

		public T Create(TArg1 param)
		{
			return _func(param);
		}
	}

	public class DelegateFactory<T, TArg1, TArg2> : IFactory<T, TArg1, TArg2>
	{
		private readonly Func<TArg1, TArg2, T> _func;

		public DelegateFactory(Func<TArg1, TArg2, T> func)
		{
			_func = func;
		}

		public T Create(TArg1 param1, TArg2 param2)
		{
			return _func(param1, param2);
		}
	}
}
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

	public class DelegateFactory<T, TParam> : IFactory<T, TParam>
	{
		private readonly Func<TParam, T> _func;

		public DelegateFactory(Func<TParam, T> func)
		{
			_func = func;
		}

		public T Create(TParam param)
		{
			return _func(param);
		}
	}
}
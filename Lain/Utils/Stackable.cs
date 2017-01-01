using System;
namespace Lain.Utils
{
	public interface Stackable<T>
	{
		T Pop ();
		void Push (T t);
		T Peek ();
	}
}

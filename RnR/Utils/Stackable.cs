using System;
namespace RnR
{
	public interface Stackable<T>
	{
		T Pop ();
		void Push (T t);
		T Peek ();
	}
}

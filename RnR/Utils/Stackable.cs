using System;
namespace RnR.Utils
{
	public interface Stackable<T>
	{
		T Pop ();
		void Push (T t);
		T Peek ();
	}
}

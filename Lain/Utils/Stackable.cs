using System;
namespace Lain.Utils
{
	/// <summary>
	/// Defines an element that can behave like a stack.
	/// </summary>
	public interface Stackable<T>
	{
		T Pop ();
		void Push (T t);
		T Peek ();
	}
}

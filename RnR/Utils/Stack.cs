using System;
using System.Collections;

namespace RnR.Utils
{
    /// <summary>
    ///   Mono didn't know about the class Stack<T> in System.Collections.Generic,
    ///   so, I implemented a wrapper for type safety.
    /// </summary>
	public class Stack<T> : Stackable<T>
	{
		private Stack innerStack;

		public Stack ()
		{
			innerStack = new Stack ();
		}

		public T Pop ()
		{
			return (T)innerStack.Pop();
		}

		public void Push (T t)
		{
			innerStack.Push (t);
		}

		public T Peek ()
		{
			return (T)innerStack.Peek ();
		}

		public bool Empty ()
		{
			return innerStack.Count == 0;
		}
	}
}

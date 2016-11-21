using System;
using System.Collections;

namespace RnR.Utils
{
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

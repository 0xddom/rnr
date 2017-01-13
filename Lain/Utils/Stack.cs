using System;
using System.Collections;

namespace Lain.Utils
{
    /// <summary>
    /// Mono didn't know about the class Stack<T> in System.Collections.Generic,
    /// so, I implemented a wrapper for type safety.
    /// </summary>
	public class Stack<T> : Stackable<T>, IEnumerable
	{
		/// <summary>
		/// The inner stack.
		/// </summary>
		private Stack innerStack;

		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Utils.Stack`1"/> class.
		/// </summary>
		public Stack ()
		{
			innerStack = new Stack ();
		}

		/// <summary>
		/// Returns the top element of the stack and removes it.
		/// </summary>
		public T Pop ()
		{
			return (T)innerStack.Pop();
		}

		/// <summary>
		/// Add a new element on the top of the stack.
		/// </summary>
		/// <param name="t">The new element.</param>
		public void Push (T t)
		{
			innerStack.Push (t);
		}

		/// <summary>
		/// Returns the top element of the stack without removing.
		/// </summary>
		public T Peek ()
		{
			return (T)innerStack.Peek ();
		}

		/// <summary>
		/// Check if the stack is empty.
		/// </summary>
		public bool Empty ()
		{
			return innerStack.Count == 0;
		}

		#region IEnumerable implementation

		/// <summary>
		/// Gets the enumerator.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator GetEnumerator ()
		{
			return innerStack.GetEnumerator ();
		}

		#endregion
	}
}

using System;

namespace Lain.Utils
{
	/// <summary>
	/// This class holds a pair of elements.
	/// 
	/// This class is mutable and not thread safe.
	/// </summary>
	public class Pair<F,S>
	{
		/// <summary>
		/// Gets or sets the first element.
		/// </summary>
		/// <value>The first element.</value>
		public F First { get; set; }

		/// <summary>
		/// Gets or sets the second element.
		/// </summary>
		/// <value>The second element.</value>
		public S Second { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Utils.Pair`2"/> class.
		/// </summary>
		/// <param name="first">First element.</param>
		/// <param name="second">Second element.</param>
		public Pair (F first, S second)
		{
			First = first;
			Second = second;
		}
	}
}


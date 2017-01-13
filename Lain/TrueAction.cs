using System;

namespace Lain
{
	/// <summary>
	/// This action always returns true.
	/// 
	/// Used in boolean logic.
	/// </summary>
	public class TrueAction : IAction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.TrueAction"/> class.
		/// </summary>
		public TrueAction ()
		{
		}

		#region IAction implementation

		/// <summary>
		/// Execute this instance.
		/// 
		/// Always returns true.
		/// </summary>
		public bool Execute ()
		{
			return true;
		}

		#endregion
	}
}


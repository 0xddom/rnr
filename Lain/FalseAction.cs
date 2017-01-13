using System;

namespace Lain
{
	/// <summary>
	/// This action will always fail.
	/// 
	/// Used for boolean logic.
	/// </summary>
	public class FalseAction : IAction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.FalseAction"/> class.
		/// </summary>
		public FalseAction ()
		{
		}

		#region IAction implementation

		/// <summary>
		/// Execute this instance.
		/// Always return false.
		/// </summary>
		public bool Execute ()
		{
			return false;
		}

		#endregion
	}
}


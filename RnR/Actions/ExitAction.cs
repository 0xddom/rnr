using System;
using Lain;

namespace RnR.Actions
{
	/// <summary>
	/// Action that exits the program
	/// </summary>
	public class ExitAction : IAction
	{
		/// <summary>
		/// The result number.
		/// </summary>
		readonly int resultNumber;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.ExitAction"/> class.
		/// </summary>
		/// <param name="resultNumber">Result number.</param>
		public ExitAction (int resultNumber)
		{
			this.resultNumber = resultNumber;
		}

		#region IAction implementation

		/// <summary>
		/// Call the exit syscall and exit the program.
		/// </summary>
		public bool Execute ()
		{
			Environment.Exit (resultNumber);
			return false;
		}

		#endregion
	}
}


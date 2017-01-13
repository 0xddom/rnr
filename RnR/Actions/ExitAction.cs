using System;
using Lain;

namespace RnR.Actions
{
	public class ExitAction : IAction
	{
		int resultNumber;

		public ExitAction (int resultNumber)
		{
			this.resultNumber = resultNumber;
		}

		#region IAction implementation

		public bool Execute ()
		{
			Environment.Exit (resultNumber);
			return false;
		}

		#endregion
	}
}


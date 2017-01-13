using System;

namespace Lain
{
	/// <summary>
	/// Chains a set of actions and executes them secuentially.
	/// 
	/// Stops the execution when an action returns false
	/// </summary>
	public class AndChain : IAction
	{
		/// <summary>
		/// The actions.
		/// </summary>
		IAction[] actions;

		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.AndChain"/> class.
		/// </summary>
		/// <param name="actions">Actions.</param>
		public AndChain (params IAction[] actions)
		{
			this.actions = actions;
		}

		#region IAction implementation

		/// <summary>
		/// Loops over the actions and executes them. When one action returns false, stops the loop and return false.
		/// 
		/// Returns the last execution result.
		/// </summary>
		public bool Execute ()
		{
			if (this.actions.Length == 0)
				return false;

			bool last_execution_result = true;
			foreach (IAction action in actions) {
				if (last_execution_result) {
					last_execution_result = action.Execute ();
				}
			}

			return last_execution_result;
		}

		#endregion
	}
}


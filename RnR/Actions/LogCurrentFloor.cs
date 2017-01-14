using System;
using Lain;
using System.Collections.Generic;

namespace RnR.Actions
{
	/// <summary>
	/// Writes to the log the current floor the player is in.
	/// </summary>
	public class LogCurrentFloor : IAction
	{
		/// <summary>
		/// A pointer to the GameState
		/// </summary>
		GameState gs;

		/// <summary>
		/// The log.
		/// </summary>
		List<string> log;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.LogCurrentFloor"/> class.
		/// </summary>
		/// <param name="gs">Gs.</param>
		/// <param name="log">Log.</param>
		public LogCurrentFloor (GameState gs, List<string> log)
		{
			this.gs = gs;
			this.log = log;
		}

		#region IAction implementation

		/// <summary>
		/// Log the message.
		/// </summary>
		public bool Execute ()
		{
			log.Add ($"You are in floor #{gs.Dungeon.CurrentFloor.Level + 1}");
			return true;
		}

		#endregion
	}
}


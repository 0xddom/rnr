using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	/// <summary>
	/// Move the player down.
	/// </summary>
	public class MoveDownAction : IAction, MoveAction
	{
		/// <summary>
		/// The dungeon floor console.
		/// </summary>
		readonly DungeonFloorConsole dfc;

		/// <summary>
		/// The game state.
		/// </summary>
		readonly GameState gs;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.MoveDownAction"/> class.
		/// </summary>
		/// <param name="gs">The game state.</param>
		/// <param name="dfc">The dungeon floor console.</param>
		public MoveDownAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

		/// <summary>
		/// Move the player down
		/// </summary>
		public bool Execute ()
		{
			var center = dfc.Center;
			if (gs.Dungeon.CurrentFloor.CanGoToDirection (RnR.World.Directions.DOWN, center)) {
				center.Y++;
				if (center.Y >= dfc.Floor.Height)
					center.Y = dfc.Floor.Height - 1;
				dfc.Center = center;
				return true;
			}
			return false;
		}

		#endregion
	}
}


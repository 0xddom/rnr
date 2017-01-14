using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	/// <summary>
	/// Move to the right action.
	/// </summary>
	public class MoveRightAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.MoveRightAction"/> class.
		/// </summary>
		/// <param name="gs">The GameState.</param>
		/// <param name="dfc">The DungeonFloorConsole.</param>
		public MoveRightAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

		/// <summary>
		/// Move the player to the right.
		/// </summary>
		public bool Execute ()
		{
			var center = dfc.Center;
			if (gs.Dungeon.CurrentFloor.CanGoToDirection (RnR.World.Directions.RIGHT, center)) {
				center.X++;
				if (center.X >= dfc.Floor.Width)
					center.X = dfc.Floor.Width - 1;
				dfc.Center = center;
				return true;
			}		
			return false;
		}

		#endregion
	}
}


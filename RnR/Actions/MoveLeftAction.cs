using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	/// <summary>
	/// Move to the left action.
	/// </summary>
	public class MoveLeftAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.MoveLeftAction"/> class.
		/// </summary>
		/// <param name="gs">Gs.</param>
		/// <param name="dfc">Dfc.</param>
		public MoveLeftAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

		/// <summary>
		/// Move the player to the action.
		/// </summary>
		public bool Execute ()
		{
			var center = dfc.Center;
			if (gs.Dungeon.CurrentFloor.CanGoToDirection (RnR.World.Directions.LEFT, center)) {
				center.X--;
				if (center.X < 0)
					center.X = 0;
				dfc.Center = center;
				return true;
			}
			return false;
		}

		#endregion
	}
}


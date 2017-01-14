using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	/// <summary>
	/// Move up action.
	/// </summary>
	public class MoveUpAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.MoveUpAction"/> class.
		/// </summary>
		/// <param name="gs">The GameState.</param>
		/// <param name="dfc">The DungeonFloorConsole.</param>
		public MoveUpAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

		/// <summary>
		/// Move the player up.
		/// </summary>
		public bool Execute ()
		{
			var center = dfc.Center;
			if (gs.Dungeon.CurrentFloor.CanGoToDirection (RnR.World.Directions.UP, center)) {
				center.Y--;
				if (center.Y < 0)
					center.Y = 0;
				dfc.Center = center;
				return true;
			}
			return false;
		}

		#endregion
	}
}


using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	public class MoveLeftAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		public MoveLeftAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

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


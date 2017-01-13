using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	public class MoveUpAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		public MoveUpAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

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


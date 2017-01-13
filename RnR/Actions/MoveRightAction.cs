using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	public class MoveRightAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		public MoveRightAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

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


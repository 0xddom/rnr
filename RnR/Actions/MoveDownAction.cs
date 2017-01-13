using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	public class MoveDownAction : IAction, MoveAction
	{
		DungeonFloorConsole dfc;
		GameState gs;

		public MoveDownAction (GameState gs, DungeonFloorConsole dfc)
		{
			this.dfc = dfc;
			this.gs = gs;
		}

		#region IAction implementation

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


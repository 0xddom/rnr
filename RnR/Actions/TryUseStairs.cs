using System;
using Lain;
using RnR.Consoles;

namespace RnR.Actions
{
	/// <summary>
	/// Check whenever the position has a stair and use it.
	/// </summary>
	public class TryUseStairs : IAction
	{
		GameState gs;
		DungeonFloorConsole dfc;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Actions.TryUseStairs"/> class.
		/// </summary>
		/// <param name="gs">The GameState.</param>
		/// <param name="dfc">The DungeonFloorConsole.</param>
		public TryUseStairs (GameState gs, DungeonFloorConsole dfc)
		{
			this.gs = gs;
			this.dfc = dfc;
		}

		#region IAction implementation

		/// <summary>
		/// Check whenever the position has a stair and use it.
		/// </summary>
		public bool Execute ()
		{
			var center = dfc.Center;
			if (gs.Dungeon.CurrentFloor.UpStair != null &&
			    center.Equals (gs.Dungeon.CurrentFloor.UpStair.Position)) {
				gs.Dungeon.GoToPreviousFloor ();
				dfc.Center = gs.Dungeon.CurrentFloor.DownStair.Position;
				dfc.Floor = gs.Dungeon.CurrentFloor;
				return true;
			} else if (center.Equals (gs.Dungeon.CurrentFloor.DownStair.Position)) {
				gs.Dungeon.GoToNextFloor ();
				dfc.Center = gs.Dungeon.CurrentFloor.UpStair.Position;
				dfc.Floor = gs.Dungeon.CurrentFloor;
				return true;
			} 
			return false;
		}

		#endregion
	}
}


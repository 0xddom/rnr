using System;
using RnR.Systems.D20.Base.FloorElements;
using Microsoft.Xna.Framework;
using SadConsole;

namespace RnR.Systems.D20.FloorElements
{
	public class Door : AbstractLockableFloorElement, Lockable
	{
		public Door (int challengeRate) 
			: base(challengeRate)
		{
		}

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance (bool inFov)
		{
			if (inFov)
				return new CellAppearance (Color.White, Color.Transparent, IsLocked ? 19: 22);
			else
				return new CellAppearance (Color.DarkGray, Color.Transparent, IsLocked ? 19: 22);
		}

		#endregion
	}
}

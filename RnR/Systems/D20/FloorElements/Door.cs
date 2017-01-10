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

		public override SadConsole.CellAppearance Appearance ()
		{
			return new CellAppearance (Color.MediumSpringGreen, Color.Transparent, 20);
		}

		#endregion
	}
}

using System;
using Lain;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractFloorElement : Drawable
	{
		public AbstractFloorElement ()
		{
		}

		#region Drawable implementation

		public abstract SadConsole.CellAppearance Appearance ();

		#endregion
	}
}

using System;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Consoles
{
	/// <summary>
	/// Sets the appearance of a floor cell that is in the fov.
	/// </summary>
	public class FloorInFovAppearance : CellAppearance
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Consoles.FloorInFovAppearance"/> class.
		/// </summary>
		public FloorInFovAppearance ()
			: base(Color.LightGray, Color.Transparent, 46)
		{
		}
	}
}


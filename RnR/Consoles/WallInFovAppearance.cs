using System;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Consoles
{
	/// <summary>
	/// Sets the appearance of a wall cell that is in the fov.
	/// </summary>
	public class WallInFovAppearance : CellAppearance
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Consoles.WallInFovAppearance"/> class.
		/// </summary>
		public WallInFovAppearance () 
			: base (Color.White, Color.Gray, 176)
		{
		}
	}
}


using System;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Consoles
{
	/// <summary>
	/// Sets the appearance of a wall cell that is out of fov.
	/// </summary>
	public class WallAppearance : CellAppearance
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Consoles.WallAppearance"/> class.
		/// </summary>
		public WallAppearance () 
			: base(Color.Gray, Color.Black, 176)
		{
		}
	}
}


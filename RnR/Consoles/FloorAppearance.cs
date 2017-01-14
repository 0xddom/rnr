using System;
using SadConsole;
using Microsoft.Xna.Framework;

namespace RnR.Consoles
{
	/// <summary>
	/// Sets the appearance of a floor cell that is out of fov.
	/// </summary>
	public class FloorAppearance : CellAppearance
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Consoles.FloorAppearance"/> class.
		/// </summary>
		public FloorAppearance () 
			: base(Color.DarkGray, Color.Transparent, 46)
		{
		}
	}
}


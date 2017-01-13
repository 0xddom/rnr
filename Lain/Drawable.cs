using System;
using SadConsole;

namespace Lain
{
	/// <summary>
	/// Sets the behaviour of an element that can be drawed on the screen.
	/// </summary>
	public interface Drawable
	{
		CellAppearance Appearance(bool inFov);
	}
}


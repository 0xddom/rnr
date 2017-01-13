using System;
using Lain.Geometry;

namespace Lain
{
	/// <summary>
	/// Tells that the element has a position in a coordinate system.
	/// </summary>
	public interface Positionable
	{
		Point2D Position {get;set;}
	}
}


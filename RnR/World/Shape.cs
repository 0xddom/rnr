using System;
using Lain.Geometry;


namespace RnR.World
{
	public interface Shape
	{
		int Area { get; }
		int Width { get; }
		int Height { get; }
		Point2D Center { get; }
	}
}

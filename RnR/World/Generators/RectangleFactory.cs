using System;
using Lain.Geometry;


namespace RnR.World.Generators
{
	public class RectangleFactory
	{
		static Random r;

		static RectangleFactory() {
			r = new Random ();
		}

		public static Rectangle CreateRandomSizeRectangle (Point2D center, int minWidth, int maxWidth, int minHeight, int maxHeight)
		{
			return new Rectangle (center, r.Next (minWidth, maxWidth), r.Next (minHeight, maxHeight));
		}
	}
}

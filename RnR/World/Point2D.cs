using System;
namespace RnR.World
{
	public class Point2D
	{
		public Point2D (int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; set; }
		public int Y { get; set; }

		public double distance (Point2D other)
		{
			return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
		}

		public Point2D midpoint (Point2D other)
		{
			return new Point2D ((X + other.X) / 2, (Y + other.Y) / 2);
		}
	}
}

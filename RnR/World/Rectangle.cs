using System;
namespace RnR.World
{
	public class Rectangle : Shape
	{
		public Rectangle (Point2D p1, Point2D p2)
		{
			P1 = p1;
			P2 = p2;
		}

		public Rectangle (Point2D center, int width, int height)
		{
			P1 = new Point2D (center.X - width / 2, center.Y - height / 2);
			P2 = new Point2D (center.X + width / 2, center.Y + height / 2);
		}

		public int Area {
			get {
				return Width * Height;
			}
		}

		public Point2D Center {
			get {
				return P1.midpoint(P2);
			}
		}

		public int Height {
			get {
				return Math.Abs(P1.Y - P2.Y);
			}
		}

		public Point2D P1 { get; set; }
		public Point2D P2 { get; set; }

		public int Width {
			get {
				return Math.Abs (P1.X - P2.X);
			}
		}

		public int Left {
			get {
				return Math.Min (P1.X, P2.X);
			}
		}

		public int Right {
			get {
				return Math.Max (P1.X, P2.X);
			}
		}

		public int Top {
			get {
				return Math.Max (P1.Y, P2.Y);
			}
		}

		public int Bottom {
			get {
				return Math.Min (P1.Y, P2.Y);
			}
		}

		public bool Contains (Point2D point)
		{
			return Left <= point.X && point.X <= Right && Bottom <= point.Y && point.Y <= Top; 
		}

		public bool Intersects (Rectangle o)
		{
			return !(Right < o.Left ||
				o.Right < Left ||
				Top < o.Bottom ||
				o.Top < Bottom);
		}
	}
}

using System;
namespace Lain.Geometry
{
	/// <summary>
	/// This class represents a mathematical point.
	/// </summary>
	public struct Point2D : IEquatable<Point2D>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Geometry.Point2D"/> struct.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public Point2D (int x, int y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Gets or sets the x.
		/// </summary>
		/// <value>The x.</value>
		public int X { get; set; }

		/// <summary>
		/// Gets or sets the y.
		/// </summary>
		/// <value>The y.</value>
		public int Y { get; set; }

		/// <summary>
		/// Returns the distance between self and other point.
		/// </summary>
		/// <param name="other">Other point.</param>
		public double distance (Point2D other)
		{
			return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
		}

		/// <summary>
		/// Returns the midpoint between self and other point.
		/// </summary>
		/// <param name="other">Other point.</param>
		public Point2D midpoint (Point2D other)
		{
			return new Point2D ((X + other.X) / 2, (Y + other.Y) / 2);
		}

		#region IEquatable implementation

		/// <summary>
		/// Determines whether the specified <see cref="Lain.Geometry.Point2D"/> is equal to the current <see cref="Lain.Geometry.Point2D"/>.
		/// </summary>
		/// <param name="other">The <see cref="Lain.Geometry.Point2D"/> to compare with the current <see cref="Lain.Geometry.Point2D"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Lain.Geometry.Point2D"/> is equal to the current
		/// <see cref="Lain.Geometry.Point2D"/>; otherwise, <c>false</c>.</returns>
		public bool Equals (Point2D other)
		{
			return X == other.X && Y == other.Y;
		}

		#endregion
	}
}

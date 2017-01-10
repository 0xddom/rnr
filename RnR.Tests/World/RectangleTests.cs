using System;
using NUnit.Framework;
using RnR.World;
using Lain.Geometry;

namespace RnR.Tests
{
	[TestFixture()]
	public class RectangleTests
	{
		private static Point2D p1 = new Point2D (9, 12);
		private static Point2D p2 = new Point2D (16, 18);
		private Point2D p3 = new Point2D (11, 14);
		private Point2D p4 = new Point2D (14, 16);
	
		// Base Rectangle
		private Rectangle br = new Rectangle (p1, p2);

		// TestRectangleIntersection for short
		private void tri(bool expected, Rectangle r1, Rectangle r2) {
			Assert.AreEqual (expected, r1.Intersects (r2));
			Assert.AreEqual (expected, r2.Intersects (r1));
		}

		[Test ()]
		public void TestRectanglesShouldIntersect() {
			var r2 = new Rectangle (new Point2D (11, 14), new Point2D (200, 200));

			//tri (true, br, r2);
		}

		[Test ()]
		public void TestRectanglesShouldNotIntersect() {
			var r2 = new Rectangle (new Point2D (4, 4), new Point2D (5, 5));

			//tri (false, br, r2);
		}

		[Test ()]
		public void TestARectangleInsideAnotherShouldIntersect() {
			var r2 = new Rectangle (p3, p4);
			//tri (true, br, r2);
		}
	}
}


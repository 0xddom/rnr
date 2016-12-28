using RnR.World.Generators;
using RnR.World;
using NUnit.Framework;

namespace RnR.Tests.World.Generators
{
	[TestFixture ()]
	public class SimpleFloorGenerationStrategyTests
	{
		[Test ()]
		public void TestDungeonHasCorrectLevel ()
		{
			var strategy = new SimpleFloorGenerationStrategy ();
			int level = 1;

			var floor = strategy.Generate (level);

			Assert.AreEqual (level, floor.Level);
		}

		[Test ()]
		public void TestDungeonHasCorrectWidth ()
		{
			var strategy = new SimpleFloorGenerationStrategy ();

			var floor = strategy.Generate (0);

			Assert.LessOrEqual (floor.Width, FloorGenerationConstrains.MAX_FLOOR_WIDTH);
			Assert.GreaterOrEqual (floor.Width, FloorGenerationConstrains.MIN_FLOOR_WIDTH);
		}

		[Test ()]
		public void TestDungeonHasCorrectHeight ()
		{
			var strategy = new SimpleFloorGenerationStrategy ();

			var floor = strategy.Generate (0);

			Assert.LessOrEqual (floor.Height, FloorGenerationConstrains.MAX_FLOOR_HEIGHT);
			Assert.GreaterOrEqual (floor.Height, FloorGenerationConstrains.MIN_FLOOR_HEIGHT);
		}

		[Test ()]
		public void PrintFloor ()
		{
			var strategy = new SimpleFloorGenerationStrategy ();
			var floor = strategy.Generate (0);

			System.Console.WriteLine ("\n DUNGEON:");
			System.Console.WriteLine (floor.ToString ());
		}
	}
}

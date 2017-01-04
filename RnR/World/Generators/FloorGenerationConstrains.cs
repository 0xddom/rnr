using System;
namespace RnR.World.Generators
{
	public class FloorGenerationConstrains
	{
		public static int MIN_FLOOR_WIDTH = 50;
		public static int MAX_FLOOR_WIDTH = 150;
		public static int MIN_FLOOR_HEIGHT = 50;
		public static int MAX_FLOOR_HEIGHT = 150;

		public static int MIN_ROOM_WIDTH = 7;
		public static int MAX_ROOM_WIDTH = 13;
		public static int MIN_ROOM_HEIGHT = 7;
		public static int MAX_ROOM_HEIGHT = 13;

		public static int MIN_ROOMS = 15;
		public static int MAX_ROOMS = 25;

		public static int MIN_FLOOR_ELEMENTS_COUNT = 10;
		public static int MAX_FLOOR_ELEMENTS_COUNT = 25;

		// 0.2 + 0.1 + 0.6 + 0.1 == 1
		public static double CHEST_PROB = 0.2;
		public static double TRAP_PROB = 0.1;
		public static double GRASS_PROG = 0.6;
		public static double FOUNTAIN_PROB = 0.1;
	}
}

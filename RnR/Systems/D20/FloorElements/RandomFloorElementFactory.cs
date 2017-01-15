using System;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class RandomFloorElementFactory : FloorElementFactory
	{
		// 0.2 + 0.1 + 0.6 + 0.1 == 1
		private double CHEST_PROB = 0.1;
		private double TRAP_PROB = 0.05;
		private double GRASS_PROG = 0.8;
		//private double FOUNTAIN_PROB = 0.05;

		Random r;

		ChestFactory chestFactory;
		RandomTrapFactory randomTrapFactory;
		RandomGrassFactory randomGrassFactory;
		FountainFactory fountainFactory;

		public RandomFloorElementFactory ()
		{
			r = new Random ();
			chestFactory = null;
			randomTrapFactory = null;
			randomGrassFactory = null;
			fountainFactory = null;
		}

		#region FloorElementFactory implementation

		public AbstractFloorElement CreateFloorElement ()
		{
			FloorElementFactory realFactory;

			double accChestProb = CHEST_PROB;
			double accTrapProb = CHEST_PROB + TRAP_PROB;
			double accGrassProb = accTrapProb + GRASS_PROG;

			double random = r.NextDouble ();

			if (random < accChestProb) {
				if (chestFactory == null)
					chestFactory = new ChestFactory ();
				realFactory = chestFactory;
			} else if (random < accTrapProb) {
				if (randomTrapFactory == null)
					randomTrapFactory = new RandomTrapFactory ();
				realFactory = randomTrapFactory;
			} else if (random < accGrassProb) {
				if (randomGrassFactory == null)
					randomGrassFactory = new RandomGrassFactory ();
				realFactory = randomGrassFactory;
			} else {
				if (fountainFactory == null)
					fountainFactory = new FountainFactory ();
				realFactory = fountainFactory;
			}

			return realFactory.CreateFloorElement ();
		}

		#endregion
	}
}


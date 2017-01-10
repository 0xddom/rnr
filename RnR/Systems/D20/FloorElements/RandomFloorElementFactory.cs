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
		private double FOUNTAIN_PROB = 0.05;

		Random r;

		public RandomFloorElementFactory ()
		{
			r = new Random ();
		}

		#region FloorElementFactory implementation

		public RnR.Systems.D20.Base.FloorElements.AbstractFloorElement CreateFloorElement ()
		{
			FloorElementFactory realFactory;

			double accChestProb = CHEST_PROB;
			double accTrapProb = CHEST_PROB + TRAP_PROB;
			double accGrassProb = accTrapProb + GRASS_PROG;

			double random = r.NextDouble ();

			if (random < accChestProb)
				realFactory = new ChestFactory ();
			else if (random < accTrapProb)
				realFactory = new RandomTrapFactory ();
			else if (random < accGrassProb)
				realFactory = new RandomGrassFactory ();
			else
				realFactory = new FountainFactory ();

			return realFactory.CreateFloorElement ();
		}

		#endregion
	}
}


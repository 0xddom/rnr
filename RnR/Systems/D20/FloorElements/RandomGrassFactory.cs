using System;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Objects;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.FloorElements
{
	public class RandomGrassFactory : FloorElementFactory
	{
		Random r;
		GameObjectFactory foodFactory;

		public RandomGrassFactory ()
		{
			r = new Random();
			foodFactory = null;
		}

		#region FloorElementFactory implementation

		public RnR.Systems.D20.Base.FloorElements.AbstractFloorElement CreateFloorElement ()
		{
			AbstractGrass newGrass = null;

			switch (r.Next (2)) {
			case 0:
				newGrass = CreateFoodGrass ();
				break;
			case 1:
				newGrass = CreateMoneyGrass ();
				break;
			}

			if (newGrass == null)
				newGrass = CreateMoneyGrass (); // Default value

			return newGrass;
		}

		#endregion

		AbstractGrass CreateFoodGrass() {
			// Initialize it only if a food grass is requested at least once.
			if (foodFactory != null)
				foodFactory = new RandomFoodFactory ();
			return new FoodGrass ((AbstractFood)foodFactory.CreateGameObject ());
		}

		AbstractGrass CreateMoneyGrass() {
			return new MoneyGrass (r.Next(10, 100));
		}
	}
}


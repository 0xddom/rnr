using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.FloorElements
{
	public class FoodGrass : AbstractGrass
	{
		private AbstractFood food;

		public FoodGrass (AbstractFood food)
		{
			this.food = food;
		}

		protected override string ApplyAction (Party target)
		{
			target.Inventory.Add (food);
			return $"Found: {food.Name}";
		}
	}
}

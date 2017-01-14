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

		protected override void ApplyAction (IGameActor target)
		{
			//target.Inventory.Add (food);
		}
	}
}

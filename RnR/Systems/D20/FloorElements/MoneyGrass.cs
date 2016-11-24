using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class MoneyGrass : AbstractGrass
	{
		private int amount;
		private bool picked;

		public MoneyGrass (int amount)
		{
			this.amount = amount;
			this.picked = false;
		}

		public override AbstractGameActor OnStep (AbstractGameActor target)
		{
			// Only apply to player actor
			if (!picked && target is PlayerGameActor) {
				target.Money += amount;
				this.picked = false;
			}
			return target;
		}
	}
}

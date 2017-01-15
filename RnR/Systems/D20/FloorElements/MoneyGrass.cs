using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class MoneyGrass : AbstractGrass
	{
		int amount;

		public MoneyGrass (int amount)
		{
			this.amount = amount;
		}

		protected override string ApplyAction (Party target)
		{
			target.Leader.Money += amount;
			return $"Found {amount} pieces of gold";
		}
	}
}

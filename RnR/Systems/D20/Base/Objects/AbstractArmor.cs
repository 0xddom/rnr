using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

	public abstract class AbstractArmor : AbstractGameObject, EquipableObject
	{
		private int bonus;
		private int maxDex;

		public int Bonus
		{
			get {
				return bonus;
			}
		}

		public int MaxDex
		{
			get {
				return maxDex;
			}
		}

		AbstractArmor (string name, string description, int weight, int price, int bonus, int maxDex) 
			: base(name,description, weight, price)
		{
			this.bonus = bonus;
			this.maxDex = maxDex;
			
		}

		public IGameActor OnEquip (IGameActor target)
		{
			target.EquipedArmor = this;
			return target;
		}
	}
}
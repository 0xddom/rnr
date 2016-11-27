using System;

namespace RnR.Systems.D20.BasePackage.GameObject
{

	public abstract class AbstractArmor : AbstractGameObject, EquipableObject
	{

		private int bonus;
		private int maxDex;


		public int getBonus()
		{
			return bonus;
		}


		public int getMaxDex()
		{
			return maxDex;
		}

		public void AbstractArmor(string name, string description, int weight, int price, int bonus, int maxDex)
		{
			this.bonus = bonus;
			this.maxDex = maxDex;
			
		}

	}
}
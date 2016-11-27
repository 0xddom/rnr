
using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{

    public abstract class AbstractPotion : AbstractGameObject , EdibleObject 
	{


        private PotionEffect effect;


        public void AbstractPotion(string name, string description, int weight, int price, PotionEffect effect)
		{
			this.effect = effect;
        }

    }
}
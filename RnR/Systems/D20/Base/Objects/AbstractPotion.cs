
using System;


namespace RnR.Systems.D20.Base.Objects;
{

    public abstract class AbstractPotion : AbstractGameObject , EdibleObject 
	{


        private PotionEffect effect;


        public AbstractPotion(string name, string description, int weight, int price, PotionEffect effect)
		{
			this.effect = effect;
        }

    }
}
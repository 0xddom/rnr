
using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{


    public abstract class AbstractJewel : AbstractGameObject , EquipableObject
	{


        private JewelEffect effect;


        public JewelEffect getEffect() 
		{

			return effect;
        }


        public void AbstractJewel(string name, string description, int weight, int price, JewelEffect effect) 
		{
			this.effect = effect;
        }

    }
}
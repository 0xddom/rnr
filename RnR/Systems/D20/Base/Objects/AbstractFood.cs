
using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{

    public abstract class AbstractFood : AbstractGameObject , EdibleObject 
	{



        private int energyGain;


        public void AbstractFood(string name, string description, int weight, int price, int eneryGain)
		{
			this.energyGain = eneryGain;

        }

    }
}
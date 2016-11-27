
using System;


namespace RnR.Systems.D20.Base.Objects;
{

    public abstract class AbstractFood : AbstractGameObject , EdibleObject 
	{



        private int energyGain;


        public AbstractFood(string name, string description, int weight, int price, int eneryGain)
		{
			this.energyGain = eneryGain;

        }

    }
}
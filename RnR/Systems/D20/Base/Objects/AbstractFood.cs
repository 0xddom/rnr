
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractFood : AbstractGameObject , EdibleObject 
	{
        private int energyGain;

        public AbstractFood(string name, string description, int weight, int price, int eneryGain) 
			: base(name, description, weight, price)
		{
			this.energyGain = eneryGain;
        }

		public void OnEat (ref GameActor target)
		{
			throw new NotImplementedException ();
		}


	}
}
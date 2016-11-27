using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractFood : AbstractGameObject , EdibleObject 
	{
        private int energyGain;

        public AbstractFood(string name, string description, int weight, int price, int eneryGain) 
			: base(name, description, weight, price)
		{
			energyGain = eneryGain;
        }

		public GameActor OnEat (GameActor target)
		{
			if (target is PlayerGameActor){
				(target as PlayerGameActor).Hunger += energyGain;
			}
			return target;
		}


	}
}
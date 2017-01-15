
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{
    public abstract class AbstractPotion : AbstractGameObject , EdibleObject 
	{
        private GameActorDecorator effect;

        public AbstractPotion(string name, string description, int weight, int price, GameActorDecorator effect) 
			: base(name, description, weight, price)
		{
			this.effect = effect;
        }

		public IGameActor OnEat (Actors.IGameActor target)
		{
			effect.Target = target;
			return effect;
		}
	}
}
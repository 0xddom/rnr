
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{


    public abstract class AbstractJewel : AbstractGameObject , EquipableObject
	{
		private GameActorDecorator effect;

        public GameActorDecorator Effect
		{
			get {
				return effect;
			}
        }

		public abstract IGameActor OnEquip (IGameActor target);

		public AbstractJewel(string name, string description, int weight, int price, GameActorDecorator effect) 
			: base(name, description, weight, price)
		{
			this.effect = effect;
        }
    }
}

using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

    public class AbstractEarring : AbstractJewel 
	{
		public AbstractEarring(string name, string description, int weight, int price, GameActorDecorator effect) 
			: base(name, description, weight, price, effect)
		{
        }

		public override IGameActor OnEquip (IGameActor target)
		{
			// Remove previously equiped earring effect
			if (target.EquipedEarring != null) {
				GameActorDecorator decorator = target.EquipedEarring.Effect;
				if (decorator != null) GameActorDecorator.Remove (target, decorator);
			}

			target.EquipedEarring = this;
			Effect.Target = target;
			return Effect;
		}
	}
}

using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractRing : AbstractJewel 
	{
		public AbstractRing(string name, string description, int weight, int price, GameActorDecorator effect) 
			: base(name, description, weight, price, effect)
		{
        }

		public override GameActor OnEquip (GameActor target)
		{
			// Remove previously equiped earring effect
			if (target.EquipedRing != null) {
				GameActorDecorator decorator = target.EquipedRing.Effect;
				if (decorator != null) GameActorDecorator.Remove (target, decorator);
			}

			target.EquipedRing = this;
			Effect.Target = target;
			return Effect;
		}
    }
}
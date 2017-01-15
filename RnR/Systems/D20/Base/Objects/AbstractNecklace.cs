
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractNecklace : AbstractJewel 
	{
		AbstractNecklace(string name, string description, int weight, int price, GameActorDecorator effect) 
			: base(name, description, weight, price, effect)
		{
        }

		public override IGameActor OnEquip (Actors.IGameActor target)
		{
			// Remove previously equiped earring effect
			if (target.EquipedNecklace != null) {
				GameActorDecorator decorator = target.EquipedNecklace.Effect;
				if (decorator != null) GameActorDecorator.Remove (target, decorator);
			}

			target.EquipedNecklace = this;
			Effect.Target = target;
			return Effect;
		}
    }
}
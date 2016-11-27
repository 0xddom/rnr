
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

		public override void OnEquip (ref GameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}
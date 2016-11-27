
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

    }
}
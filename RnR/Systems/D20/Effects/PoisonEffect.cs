using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Effects
{
	public class PoisonEffect : GameActorDecorator
	{
		public PoisonEffect (GameActor target) 
			: base(target)
		{
		}
	}
}

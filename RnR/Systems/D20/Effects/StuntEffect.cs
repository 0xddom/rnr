using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Effects
{
	public class StuntEffect : GameActorDecorator
	{
		public StuntEffect (GameActor target) 
			: base(target)
		{
		}
	}
}

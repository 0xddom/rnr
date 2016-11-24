using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class Fountain : AbstractFloorElement, OnStepListener
	{
		public AbstractGameActor OnStep (AbstractGameActor target)
		{
			if (target is PlayerGameActor) {
				target.HitPoints = target.MaxHitPoints;
			}
			return target;
		}
	}
}

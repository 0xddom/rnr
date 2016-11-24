using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractGrass : AbstractFloorElement, OnStepListener
	{
		protected bool picked;

		public AbstractGrass ()
		{
			picked = false;
		}

		public AbstractGameActor OnStep (AbstractGameActor target)
		{
			if (!picked && target is PlayerGameActor) {
				ApplyAction (target);
				picked = true;
			}
			return target;
		}

		protected abstract void ApplyAction (AbstractGameActor target);
	}
}

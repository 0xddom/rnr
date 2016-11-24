using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractGrass : AbstractFloorElement, OnStepListener
	{
		public AbstractGrass ()
		{
		}

		public abstract AbstractGameActor OnStep (AbstractGameActor target);
	}
}

using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractTrap : AbstractFloorElement, OnStepListener
	{
		protected TrapEffect effect;
		protected bool armed;

		public AbstractTrap ()
		{
		}

		public void Arm ()
		{
			armed = true;
		}

		public void Disarm ()
		{
			armed = false;
		}

		public abstract AbstractGameActor OnStep (AbstractGameActor target);

		public bool Armed { get { return armed; } }
	}
}

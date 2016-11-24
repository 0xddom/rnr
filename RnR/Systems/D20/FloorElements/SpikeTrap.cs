using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

namespace RnR.Systems.D20.FloorElements
{
	public class SpikeTrap : AbstractMechanicalTrap
	{
		public SpikeTrap () : base (new SpikeEffect())
		{
		}

		public override AbstractGameActor OnStep (AbstractGameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}

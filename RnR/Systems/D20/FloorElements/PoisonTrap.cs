using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

namespace RnR.Systems.D20.FloorElements
{
	public class PoisonTrap : AbstractMechanicalTrap
	{
		public PoisonTrap () : base(new PoisonEffect())
		{
		}

		public override AbstractGameActor OnStep (AbstractGameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}

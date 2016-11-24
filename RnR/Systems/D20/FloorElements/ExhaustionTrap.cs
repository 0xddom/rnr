using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

namespace RnR.Systems.D20.FloorElements
{
	public class ExhaustionTrap : AbstractMagicalTrap
	{
		public ExhaustionTrap () : base (new ExhaustionEffect())
		{
		}

		public override AbstractGameActor OnStep (AbstractGameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}

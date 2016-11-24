using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;

namespace RnR.Systems.D20.FloorElements
{
	public class StuntTrap : AbstractMagicalTrap
	{
		public StuntTrap () : base(new StuntEffect())
		{
		}

		public override AbstractGameActor OnStep (AbstractGameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}

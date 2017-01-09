using System;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class RandomTrapFactory : FloorElementFactory
	{
		Random r;

		public RandomTrapFactory ()
		{
			r = new Random();
		}

		#region FloorElementFactory implementation

		public RnR.Systems.D20.Base.FloorElements.AbstractFloorElement CreateFloorElement ()
		{
			AbstractTrap newTrap = null;

			switch (r.Next (4)) {
			case 0:
				newTrap = CreateSpikeTrap ();
				break;
			case 1:
				newTrap = CreatePoisonTrap ();
				break;
			case 2:
				newTrap = CreateStuntTrap ();
				break;
			case 3:
				newTrap = CreateExhaustionTrap ();
				break;
			}

			if (newTrap == null)
				newTrap = CreateSpikeTrap (); // Default value

			return newTrap;
		}

		#endregion

		AbstractTrap CreateSpikeTrap() {
			return new SpikeTrap (1, 8, 20);
		}

		AbstractTrap CreatePoisonTrap() {
			return new PoisonTrap (20);
		}

		AbstractTrap CreateStuntTrap() {
			return new StuntTrap (20);
		}

		AbstractTrap CreateExhaustionTrap() {
			return new ExhaustionTrap (1, 10, 20);
		}
	}
}


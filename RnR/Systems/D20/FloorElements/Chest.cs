using System;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class Chest : AbstractLockableFloorElement, Looteable
	{
		public Chest (int challengeRate) 
			: base(challengeRate)
		{
		}
	}
}

using System;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public class Door : AbstractLockableFloorElement, Lockable
	{
		public Door (int challengeRate) 
			: base(challengeRate)
		{
		}
	}
}

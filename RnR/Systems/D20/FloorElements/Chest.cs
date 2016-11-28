using System.Collections.Generic;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.FloorElements
{
	public class Chest : AbstractLockableFloorElement, Looteable
	{
		List<GameObject> objects;

		public Chest (int challengeRate, List<GameObject> objects)
			: base (challengeRate)
		{
			this.objects = objects;
		}

		public bool CanInspect ()
		{
			return !IsLocked;
		}

		public List<GameObject> Inspect ()
		{
			if (IsLocked) throw new CantInspectException ();
			return objects;
		}
	}
}

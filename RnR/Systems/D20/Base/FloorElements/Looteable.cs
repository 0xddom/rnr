using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Base.FloorElements
{
	public interface Looteable
	{
		bool CanInspect ();
		List<GameObject> Inspect ();
	}
}

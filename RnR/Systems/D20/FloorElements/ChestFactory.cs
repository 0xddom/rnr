using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.FloorElements
{
	public class ChestFactory : FloorElementFactory
	{
		Random r;

		public ChestFactory ()
		{
			r = new Random ();
		}

		#region FloorElementFactory implementation

		public RnR.Systems.D20.Base.FloorElements.AbstractFloorElement CreateFloorElement ()
		{
			List<GameObject> objects = new List<GameObject> ();

			for (int i = r.Next (1, 6); i >= 0; i--) {
				// add random object
			}

			return new Chest (20, objects);
		}

		#endregion
	}
}


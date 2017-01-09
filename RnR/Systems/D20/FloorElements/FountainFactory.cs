using System;

namespace RnR.Systems.D20.FloorElements
{
	public class FountainFactory : FloorElementFactory
	{
		public FountainFactory ()
		{
		}

		#region FloorElementFactory implementation

		public RnR.Systems.D20.Base.FloorElements.AbstractFloorElement CreateFloorElement ()
		{
			return new Fountain ();
		}

		#endregion
	}
}


using System;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.FloorElements
{
	public interface FloorElementFactory
	{
		AbstractFloorElement CreateFloorElement();
	}
}


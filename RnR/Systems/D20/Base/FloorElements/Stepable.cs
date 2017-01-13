using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public interface Stepable
	{
		GameActor OnStep (GameActor target);
	}
}

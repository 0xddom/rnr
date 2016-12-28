using System;
namespace RnR.World.Generators
{
	public interface FloorGenerationStrategy
	{
		DungeonFloor Generate (int level);
	}
}

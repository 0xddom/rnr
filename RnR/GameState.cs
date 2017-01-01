using System;
using RnR.World;
using RnR.World.Generators;

namespace RnR
{
	public class GameState
	{
		public Dungeon Dungeon { get; private set; }

		public GameState ()
		{
			Dungeon = new Dungeon (new SimpleFloorGenerationStrategy());
		}
	}
}


using System;
using System.Collections.Generic;
using RnR.World.Generators;

namespace RnR.World
{
	public class Dungeon
	{
		List<DungeonFloor> floors;
		int currentFloor;
		FloorGenerationStrategy strategy;

		public Dungeon (FloorGenerationStrategy strategy)
		{
			floors = new List<DungeonFloor> ();
			this.strategy = strategy;
			currentFloor = 0;
			AddNewFloor ();
		}

		void AddNewFloor ()
		{
			floors.Add (strategy.Generate (currentFloor));
		}

		public DungeonFloor CurrentFloor {
			get {
				return floors [currentFloor];
			}
		}

		public void GoToNextFloor ()
		{
			if (++currentFloor == floors.Count) {
				AddNewFloor ();	
			}
		}

		public void GoToPreviousFloor ()
		{
			currentFloor--;
		}
	}
}

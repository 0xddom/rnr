using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RogueSharp;

namespace RnR.World
{
	public class DungeonFloor : Map
	{
		List<Room> rooms;
		List<AbstractFloorElement> floorElements;
		List<AbstractGameActor> npcs;
		int level;

		public DungeonFloor (int level, int width, int height)
		{
			rooms = new List<Room> ();
			floorElements = new List<AbstractFloorElement> ();
			npcs = new List<AbstractGameActor> ();
			this.level = level;
			Initialize (width, height);
		}

		public int StartRoom { get; set; }
	}
}

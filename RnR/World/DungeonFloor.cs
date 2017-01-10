using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RogueSharp;
using Lain.Geometry;
using RnR.Systems.D20.FloorElements;

namespace RnR.World
{
	public class DungeonFloor : Map
	{
		List<Room> rooms;
		Dictionary<Point2D, AbstractFloorElement> floorElements;
	//	List<AbstractGameActor> npcs;
		int level;
		public Stair UpStair { get; set; }
		public Stair DownStair { get; set; }

		public DungeonFloor (int level, int width, int height)
		{
			rooms = new List<Room> ();
			floorElements = new Dictionary<Point2D, AbstractFloorElement> ();
	//		npcs = new List<AbstractGameActor> ();
			this.level = level;
			Initialize (width, height);
		}

		public void AddRooms(ICollection<Room> newRooms) {
			rooms.AddRange (newRooms);
		}

		public void AddFloorElement(Point2D pos, AbstractFloorElement e) {
			floorElements.Add (pos, e);
		}

		public Room StartRoom { get { return rooms [StartRoomIndex]; } }

		public int StartRoomIndex { get; set; }

		public int Level { get { return level; } }

		public Dictionary<Point2D, AbstractFloorElement> FloorElements { get { return floorElements; } }
	}
}

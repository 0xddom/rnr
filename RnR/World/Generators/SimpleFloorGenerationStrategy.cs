using System;
using System.Collections.Generic;
using System.Linq;
using RogueSharp.Algorithms;

namespace RnR.World.Generators
{
	public class SimpleFloorGenerationStrategy : FloorGenerationStrategy
	{
		readonly Random r;
		DungeonFloor newFloor;

		public SimpleFloorGenerationStrategy ()
		{
			r = new Random ();
		}

		public DungeonFloor Generate (int level)
		{
			int floorWidth = FloorWidth;
			int floorHeight = FloorHeight;

			newFloor = new DungeonFloor (level, floorWidth, floorHeight);

			// Generation

			var rooms = new List<Rectangle> ();
			CreateRoomsRects (ref rooms, floorWidth, floorHeight);

			EdgeWeightedDigraph graph;
			ConnectRooms (out graph, rooms);



			return newFloor;
		}

		void ConnectRooms (out EdgeWeightedDigraph graph, List<Rectangle> rooms)
		{
			var edges = new List<DirectedEdge> ();
			for (int i = 0; i < rooms.Count; i++)
				for (int j = 0; j < rooms.Count; j++)
					if (rooms[i] != rooms[j]) {
						edges.Add (new DirectedEdge (i, j, rooms [i].Center.distance (rooms [j].Center)));
						edges.Add (new DirectedEdge (j, i, rooms [j].Center.distance (rooms [i].Center)));
					}

			graph = new EdgeWeightedDigraph(rooms.Count);
			foreach (DirectedEdge edge in edges)
				graph.AddEdge (edge);
		}

		void CreateRoomsRects (ref List<Rectangle> rooms, int floorWidth, int floorHeight)
		{
			var roomsCount = r.Next (FloorGenerationConstrains.MIN_ROOMS, FloorGenerationConstrains.MAX_ROOMS);
			while (rooms.Count < roomsCount) {
				var center = new Point2D (
					r.Next (FloorGenerationConstrains.MAX_ROOM_WIDTH / 2, floorWidth - FloorGenerationConstrains.MAX_ROOM_WIDTH / 2),
					r.Next (FloorGenerationConstrains.MAX_ROOM_HEIGHT / 2, floorHeight - FloorGenerationConstrains.MAX_FLOOR_HEIGHT / 2)
				);

				var rect = RectangleFactory.CreateRandomSizeRectangle (center,
																	  FloorGenerationConstrains.MIN_ROOM_WIDTH,
																	  FloorGenerationConstrains.MAX_ROOM_WIDTH,
																	  FloorGenerationConstrains.MIN_ROOM_HEIGHT,
																	  FloorGenerationConstrains.MAX_ROOM_HEIGHT);
				bool newRoomIntersects = rooms.Any ((Rectangle r) => r.Intersects (rect));

				if (!newRoomIntersects) {
					rooms.Add (rect);
				}
			}

			foreach (Rectangle rect in rooms) {
				SetRoomProperties (rect);
			}
		}

		void SetRoomProperties (Rectangle room)
		{
			for (int i = room.Left; i < room.Right; i++)
				for (int j = room.Bottom; j < room.Top; j++)
					newFloor.SetCellProperties (i, j, true, true, true);
		}

		int FloorWidth {
			get {
				return r.Next (FloorGenerationConstrains.MIN_FLOOR_WIDTH, FloorGenerationConstrains.MAX_FLOOR_WIDTH);
			}
		}

		int FloorHeight {
			get {
				return r.Next (FloorGenerationConstrains.MIN_FLOOR_HEIGHT, FloorGenerationConstrains.MAX_FLOOR_HEIGHT);
			}
		}

	}

}

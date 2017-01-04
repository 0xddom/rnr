using System;
using System.Collections.Generic;
using System.Linq;
using RogueSharp.Algorithms;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.World.Generators
{
    public class SimpleFloorGenerationStrategy : FloorGenerationStrategy
    {
        readonly Random r;
        DungeonFloor newFloor;

		private int floorWidth;
		private int floorHeight;

        public SimpleFloorGenerationStrategy ()
        {
            r = new Random ();
			floorWidth = -1;
			floorHeight = -1;
        }

		private int RandomRoomIndex(List<Rectangle> rooms) {
			return r.Next (rooms.Count - 1);
		}

        public DungeonFloor Generate (int level)
        {
            newFloor = new DungeonFloor (level, FloorWidth, FloorHeight);

            // Generation

			List<Rectangle> rooms = new List<Rectangle> ();
            CreateRoomsRects (rooms);

			int base_room = RandomRoomIndex (rooms);

            EdgeWeightedDigraph graph;
			ConnectRooms (out graph, rooms);


			DijkstraShortestPath dijkstra = new DijkstraShortestPath (graph, base_room);
			List<IEnumerable<DirectedEdge>> pathToRooms = new List<IEnumerable<DirectedEdge>>();
			for (int i = 0; i < rooms.Count; i++) {
				if (i != base_room) {
					pathToRooms.Add (dijkstra.PathTo (i));
				}
			}

			DrawRoomConections (pathToRooms, rooms);

			newFloor.AddRooms (rooms.ConvertAll ((roomRect => new Room (roomRect))));

			SetupStairs (level, rooms);

			AddFloorElements (rooms);

            return newFloor;
        }

		void AddFloorElements (List<Rectangle> rooms)
		{
			int floorElementsCount = r.Next (FloorGenerationConstrains.MIN_FLOOR_ELEMENTS_COUNT, FloorGenerationConstrains.MAX_FLOOR_ELEMENTS_COUNT);
			Dictionary<Point2D, AbstractFloorElement> floorElements = new Dictionary<Point2D, AbstractFloorElement> ();

			int i = 0;
			while (i < floorElementsCount) {
				// Generate random element

				// Choose a room

				// Get a random coordinate in that room

				// If not collide, add the element
			}
		}

		void SetupStairs(int level, List<Rectangle> rooms) {
			int upStairsRoom = -1;
			int downStairsRoom;

			if (level > 0) {
				// Add up stairs
				upStairsRoom = RandomRoomIndex (rooms);
				newFloor.StartRoomIndex = upStairsRoom;

				// Add up stair
			} else {
				newFloor.StartRoomIndex = RandomRoomIndex (rooms);
			}

			do {
				downStairsRoom = RandomRoomIndex (rooms);
			} while(downStairsRoom == upStairsRoom);

			// Add down stair
		}

		void ConnectRooms(out EdgeWeightedDigraph graph, List<Rectangle> rooms)
        {
			graph = new EdgeWeightedDigraph(rooms.Count);
            for (int i = 0; i < rooms.Count; i++)
                for (int j = 0; j < rooms.Count; j++)
                    if (rooms[i] != rooms[j]) {
						graph.AddEdge (new DirectedEdge (i, j, (r.NextDouble() + 0.1) * rooms [i].Center.distance (rooms [j].Center)));
						graph.AddEdge (new DirectedEdge (j, i, (r.NextDouble() + 0.1) * rooms [j].Center.distance (rooms [i].Center)));
                    }
        }

		void DrawRoomConections(List<IEnumerable<DirectedEdge>> paths, List<Rectangle> rooms)
		{
			List<DirectedEdge> alreadyDrawed = new List<DirectedEdge> ();
			foreach (var path in paths)
				foreach (var edge in path) 
					if (!alreadyDrawed.Contains (edge)) {
						alreadyDrawed.Add (edge);
						ConnectTwoRooms (rooms [edge.From], rooms [edge.To]);
					}
		}

		void ConnectTwoRooms(Rectangle room1, Rectangle room2) 
		{
			int _from, to;

			if (r.NextDouble () < 0.5) {
				_from = (int)Math.Min (room1.Center.X, room2.Center.X);
				to = 	(int)Math.Max (room1.Center.X, room2.Center.X);
				SetLineXProperties (_from, to, room1.Center.Y);

				_from = (int)Math.Min (room1.Center.Y, room2.Center.Y);
				to = 	(int)Math.Max (room1.Center.Y, room2.Center.Y);
				SetLineYProperties (_from, to, room2.Center.X);
			} else {
				_from = (int)Math.Min (room1.Center.X, room2.Center.X);
				to = 	(int)Math.Max (room1.Center.X, room2.Center.X);
				SetLineXProperties (_from, to, room2.Center.Y);

				_from = (int)Math.Min (room1.Center.Y, room2.Center.Y);
				to = 	(int)Math.Max (room1.Center.Y, room2.Center.Y);
				SetLineYProperties (_from, to, room1.Center.X);
			}
		}

		int NearestIndex(List<Rectangle> rooms, int base_index) 
		{
			int nearest = int.MaxValue;
			for (int i = 0; i < rooms.Count; i++) {
				if (i != base_index) {
					nearest = (int)Math.Floor(Math.Min (nearest, rooms [i].Center.distance (rooms [base_index].Center)));
				}
			}

			return nearest;
		}

        void CreateRoomsRects (List<Rectangle> rooms)
        {
            var roomsCount = r.Next (FloorGenerationConstrains.MIN_ROOMS, FloorGenerationConstrains.MAX_ROOMS);
			int retries = 0;
			int maxRetries = 50;
            while (retries < maxRetries && rooms.Count < roomsCount) {
                var center = new Point2D (
					r.Next (FloorGenerationConstrains.MAX_ROOM_WIDTH / 2, FloorWidth - FloorGenerationConstrains.MAX_ROOM_WIDTH / 2),
					r.Next (FloorGenerationConstrains.MAX_ROOM_HEIGHT / 2, FloorHeight - FloorGenerationConstrains.MAX_ROOM_HEIGHT / 2)
                );

                var rect = RectangleFactory.CreateRandomSizeRectangle (center,
                                                                       FloorGenerationConstrains.MIN_ROOM_WIDTH,
                                                                       FloorGenerationConstrains.MAX_ROOM_WIDTH,
                                                                       FloorGenerationConstrains.MIN_ROOM_HEIGHT,
                                                                       FloorGenerationConstrains.MAX_ROOM_HEIGHT);
                bool newRoomIntersects = rooms.Any ((Rectangle r) => r.Intersects (rect));

				if (!newRoomIntersects) {
					rooms.Add (rect);
					SetRoomProperties (rect);
					retries = 0;
				} else {
					retries++;
				}
            }
        }

        void SetRoomProperties (Rectangle room)
        {
            for (int i = room.Left; i < room.Right; i++)
                for (int j = room.Bottom; j < room.Top; j++)
                    newFloor.SetCellProperties (i, j, true, true, true);
        }

		void SetLineXProperties (int _from, int to, int y) {
			for (int i = _from; i < to+1; i++) 
				newFloor.SetCellProperties (i, y, true, true, true);
		}

		void SetLineYProperties (int _from, int to, int x) {
			for (int i = _from; i < to+1; i++) 
				newFloor.SetCellProperties (x, i, true, true, true);
		}

        int FloorWidth {
            get {
				if(floorWidth == -1) floorWidth = r.Next (FloorGenerationConstrains.MIN_FLOOR_WIDTH, FloorGenerationConstrains.MAX_FLOOR_WIDTH);
				return floorWidth;
            }
        }

        int FloorHeight {
            get {
				if(floorHeight == -1) floorHeight = r.Next (FloorGenerationConstrains.MIN_FLOOR_HEIGHT, FloorGenerationConstrains.MAX_FLOOR_HEIGHT);
				return floorHeight;
            }
        }
    }
}

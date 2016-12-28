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
            CreateRoomsRects (rooms, floorWidth, floorHeight);

			int base_room = r.Next (rooms.Count - 1);

            EdgeWeightedDigraph graph;
			ConnectRooms (out graph, rooms, base_room);


			DijkstraShortestPath dijkstra = new DijkstraShortestPath (graph, base_room);
			List<IEnumerable<DirectedEdge>> pathToRooms = new List<IEnumerable<DirectedEdge>>();
			for (int i = 0; i < rooms.Count; i++) {
				if (i != base_room) {
					pathToRooms.Add (dijkstra.PathTo (i));
				}
			}

			System.Console.WriteLine ($"Base room: {base_room}\nTotal rooms: {rooms.Count}");
			//System.Console.Write ($"{base_room}({rooms[base_room].Center.X},{rooms[base_room].Center.Y})");
			foreach (IEnumerable<DirectedEdge> path in pathToRooms) {
				System.Console.Write ($"{base_room}({rooms[base_room].Center.X},{rooms[base_room].Center.Y})");

				foreach (DirectedEdge edge in path) {
					System.Console.Write ($" -> {edge.To}({rooms[edge.To].Center.X},{rooms[edge.To].Center.Y})");
				}
				System.Console.WriteLine ("");
			}

			DrawRoomConections (pathToRooms, rooms);

            return newFloor;
        }

		void ConnectRooms(out EdgeWeightedDigraph graph, List<Rectangle> rooms, int base_room)
        {
            var edges = new List<DirectedEdge> ();
            for (int i = 0; i < rooms.Count; i++)
                for (int j = 0; j < rooms.Count; j++)
                    if (rooms[i] != rooms[j]) {
						edges.Add (new DirectedEdge (i, j, (r.NextDouble() + 0.1) * rooms [i].Center.distance (rooms [j].Center)));
						edges.Add (new DirectedEdge (j, i, (r.NextDouble() + 0.1) * rooms [j].Center.distance (rooms [i].Center)));
                    }

            graph = new EdgeWeightedDigraph(rooms.Count);
            foreach (DirectedEdge edge in edges)
                graph.AddEdge (edge);
			//var paths = new List<DirectedEdge> ();

        }

		void DrawRoomConections(List<IEnumerable<DirectedEdge>> paths, List<Rectangle> rooms)
		{
			List<DirectedEdge> alreadyDrawed = new List<DirectedEdge> ();
			foreach (var path in paths)
				foreach (var edge in path) {
					if (!alreadyDrawed.Contains (edge)) {
						alreadyDrawed.Add (edge);
						ConnectTwoRooms (rooms [edge.From], rooms [edge.To]);
					}
				}
		}

		void ConnectTwoRooms(Rectangle room1, Rectangle room2) 
		{
			int _from, to;

			if (r.NextDouble () < 0.5) {
				_from = (int)Math.Min (room1.Center.X, room2.Center.X);
				to = (int)Math.Max (room1.Center.X, room2.Center.X);
				SetLineXProperties (_from, to, room1.Center.Y);

				_from = (int)Math.Min (room1.Center.Y, room2.Center.Y);
				to = (int)Math.Max (room1.Center.Y, room2.Center.Y);
				SetLineYProperties (_from, to, room2.Center.X);
			} else {
				_from = (int)Math.Min (room1.Center.X, room2.Center.X);
				to = (int)Math.Max (room1.Center.X, room2.Center.X);
				SetLineXProperties (_from, to, room2.Center.Y);

				_from = (int)Math.Min (room1.Center.Y, room2.Center.Y);
				to = (int)Math.Max (room1.Center.Y, room2.Center.Y);
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

        void CreateRoomsRects (List<Rectangle> rooms, int floorWidth, int floorHeight)
        {
            var roomsCount = r.Next (FloorGenerationConstrains.MIN_ROOMS, FloorGenerationConstrains.MAX_ROOMS);
			int retries = 0;
			int maxRetries = 50;
            while (retries < maxRetries && rooms.Count < roomsCount) {
                var center = new Point2D (
					r.Next (FloorGenerationConstrains.MAX_ROOM_WIDTH / 2, floorWidth - FloorGenerationConstrains.MAX_ROOM_WIDTH / 2),
					r.Next (FloorGenerationConstrains.MAX_ROOM_HEIGHT / 2, floorHeight - FloorGenerationConstrains.MAX_ROOM_HEIGHT / 2)
                );

                var rect = RectangleFactory.CreateRandomSizeRectangle (center,
                                                                       FloorGenerationConstrains.MIN_ROOM_WIDTH,
                                                                       FloorGenerationConstrains.MAX_ROOM_WIDTH,
                                                                       FloorGenerationConstrains.MIN_ROOM_HEIGHT,
                                                                       FloorGenerationConstrains.MAX_ROOM_HEIGHT);
                bool newRoomIntersects = rooms.Any ((Rectangle r) => r.Intersects (rect));

				if (!newRoomIntersects) {
					rooms.Add (rect);
					retries = 0;
				} else {
					retries++;
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

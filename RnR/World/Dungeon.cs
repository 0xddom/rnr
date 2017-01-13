using System;
using System.Collections.Generic;
using RnR.World.Generators;
using Lain.Geometry;
using RogueSharp;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.World
{
	public class Dungeon
	{
		int FOV_RADIUS = 6;

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

		private void SetFovAsVisible(Point2D center) {
			CurrentFloor.ComputeFov (center.X, center.Y, FOV_RADIUS, true);

			foreach (Cell c in CurrentFloor.GetCellsInRadius(center.X, center.Y, FOV_RADIUS)) 
				if (c.IsInFov) 
					CurrentFloor.SetCellProperties (c.X, c.Y, c.IsTransparent, c.IsWalkable, true);
		}

		private void CheckIfActorSteped(Point2D p) {
			if (CurrentFloor.FloorElements.ContainsKey (p)) {
				var e = CurrentFloor.FloorElements [p];
				if (e is Stepable) {
					//System.Console.WriteLine ($"Steped over a {e.GetType().Name}");
					//(e as OnStepListener).OnStep (null);
				}
			}
		}

		public void Update(Point2D center) {
			SetFovAsVisible (center);
			CheckIfActorSteped (center);
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
			if (currentFloor < 0)
				currentFloor = 0;
		}
	}
}

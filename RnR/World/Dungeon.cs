using System;
using System.Collections.Generic;
using RnR.World.Generators;
using Lain.Geometry;
using RogueSharp;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20;

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

		private void CheckIfActorSteped(Party p, List<string> log) {
			if (CurrentFloor.FloorElements.ContainsKey (p.Leader.Position)) {
				var e = CurrentFloor.FloorElements [p.Leader.Position];
				if (e is Stepable) {
					string msg = (e as Stepable).OnStep (p);
					if (msg != null)
						log.Add (msg);
					//System.Console.WriteLine ($"Steped over a {e.GetType().Name}");
					//(e as OnStepListener).OnStep (null);
				}
			}
		}

		public void Update(Party party, List<string> log) {
			SetFovAsVisible (party.Leader.Position);
			CheckIfActorSteped (party, log);
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

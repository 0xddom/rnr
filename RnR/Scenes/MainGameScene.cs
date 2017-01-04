using System;
using Lain.Views;
using RnR.Consoles;
using Lain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RnR.Scenes
{
	/// <summary>
	/// This class shows the exploration screen and bind actions to navigate to other parts of the game.
	/// </summary>
	public class MainGameScene : Scene
	{
		#region View stuff

		DungeonFloorConsole dungeonFloorConsole;

		#endregion

		#region Model stuff

		GameState gameState;

		#endregion

		public override void OnCreate ()
		{
			int dungeonConsoleWidth = (int)Math.Floor(Configuration.GridWidth * 0.8);
			int dungeonConsoleHeight = (int)Math.Floor(Configuration.GridHeight * 0.8);

			gameState = new GameState ();

			SetBackground (Color.Black);

			dungeonFloorConsole = new DungeonFloorConsole (gameState.Dungeon.CurrentFloor, dungeonConsoleWidth, dungeonConsoleHeight);
			Add (dungeonFloorConsole);
		}

		public override void OnPause ()
		{
		}

		public override void OnResume ()
		{
		}

		public override void OnDestroy ()
		{
		}

		public override void Update(GameTime delta) {
			KeyboardState state = Keyboard.GetState ();

			var center = dungeonFloorConsole.center;

			if (state.IsKeyDown (Keys.Left)) {
				center.X--;
				if (center.X < 0)
					center.X = 0;
			} else if (state.IsKeyDown (Keys.Right)) {
				center.X++;
				if (center.X >= dungeonFloorConsole.floor.Width)
					center.X = dungeonFloorConsole.floor.Width - 1;
			} else if (state.IsKeyDown (Keys.Up)) {
				center.Y--;
				if (center.Y < 0)
					center.Y = 0;
			} else if (state.IsKeyDown (Keys.Down)) {
				center.Y++;
				if (center.Y >= dungeonFloorConsole.floor.Height)
					center.Y = dungeonFloorConsole.floor.Height - 1;
			}

			dungeonFloorConsole.center = center;

			base.Update (delta);
		}
	}
}


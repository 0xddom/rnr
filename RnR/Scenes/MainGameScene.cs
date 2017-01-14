using System;
using Lain.Views;
using RnR.Consoles;
using Lain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using RnR.Actions;

namespace RnR.Scenes
{
	/// <summary>
	/// This class shows the exploration screen and bind actions to navigate to other parts of the game.
	/// </summary>
	public class MainGameScene : Scene
	{
		#region View stuff

		DungeonFloorConsole dungeonFloorConsole;
		GameLogConsole gameLogConsole;

		#endregion

		#region Model stuff

		GameState gameState;

		List<string> log;

		#endregion

		int WALK_DELAY = 3;
		int delay = 0;

		/// <summary>
		/// Called when the scene is loaded.
		/// </summary>
		public override void OnCreate ()
		{
			int dungeonConsoleWidth = (int)Math.Floor (Configuration.GridWidth * 0.8);
			int dungeonConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 0.8);
			int gameLogConsoleWidht = dungeonConsoleWidth;
			int gameLogConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 0.2);

			gameState = new GameState ();
			log = new List<string> ();
			(new LogCurrentFloor (gameState, log)).Execute ();

			dungeonFloorConsole = new DungeonFloorConsole (gameState.Dungeon.CurrentFloor, dungeonConsoleWidth, dungeonConsoleHeight);
			gameLogConsole = new GameLogConsole (log, Math.Min (gameLogConsoleHeight - 2, 11), gameLogConsoleWidht, gameLogConsoleHeight);
			gameLogConsole.Position = new Point (0, dungeonConsoleHeight + 1);
			Add (dungeonFloorConsole);
			Add (gameLogConsole);

			SetBackground (new Color (new Vector3 (0x12, 0x13, 0x14)));

			gameState.Dungeon.Update (dungeonFloorConsole.Center);
			dungeonFloorConsole.Update ();
		}

		/// <summary>
		/// Called when the scene is paused.
		/// </summary>
		public override void OnPause ()
		{
		}

		/// <summary>
		/// Called when the scene is resumed.
		/// </summary>
		public override void OnResume ()
		{
		}

		/// <summary>
		/// Called when the scene is destroyed.
		/// </summary>
		public override void OnDestroy ()
		{
		}

		/// <summary>
		/// Handles the input.
		/// </summary>
		/// <returns>An Action corresponding to the input.</returns>
		private IAction HandleInput ()
		{
			KeyboardState state = Keyboard.GetState ();
			IAction action = new FalseAction ();

			if (state.IsKeyDown (Keys.Escape)) {
				return new ExitAction (0);
			}

			if (delay == 0) {
				delay = WALK_DELAY;
				if (state.IsKeyDown (Keys.Left)) {
					action = new MoveLeftAction (gameState, dungeonFloorConsole);
				} else if (state.IsKeyDown (Keys.Right)) {
					action = new MoveRightAction (gameState, dungeonFloorConsole);
				} else if (state.IsKeyDown (Keys.Up)) {
					action = new MoveUpAction (gameState, dungeonFloorConsole);
				} else if (state.IsKeyDown (Keys.Down)) {
					action = new MoveDownAction (gameState, dungeonFloorConsole);
				}
			}
			if (delay > 0)
				delay--;

			return action;
		}

		/// <summary>
		/// Called during the update step in the game loop.
		/// </summary>
		/// <param name="delta">Delta.</param>
		public override void Update (GameTime delta)
		{
			KeyboardState state = Keyboard.GetState ();
			IAction action = HandleInput ();

			if (action.Execute () && action is MoveAction)
				(new AndChain (new TryUseStairs (gameState, dungeonFloorConsole),
					new LogCurrentFloor (gameState, log))).Execute ();

			gameState.Dungeon.Update (dungeonFloorConsole.Center);

			base.Update (delta);
		}
	}
}


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
		PartyStatusConsole statusConsole;

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
			base.OnCreate ();

			var dungeonConsoleWidth = (int)Math.Floor (Configuration.GridWidth * 0.8);
			var dungeonConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 0.8);
			var gameLogConsoleWidht = dungeonConsoleWidth;
			var gameLogConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 0.2);
			var statusConsoleWidth = (int)Math.Floor (Configuration.GridWidth * 0.2);
			var statusConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 1.0);

			gameState = GameState.Instance;
			log = new List<string> ();
			(new LogCurrentFloor (gameState, log)).Execute ();

			dungeonFloorConsole = new DungeonFloorConsole (gameState.Dungeon.CurrentFloor, gameState.Party,  dungeonConsoleWidth, dungeonConsoleHeight);
			gameLogConsole = new GameLogConsole (log, Math.Min (gameLogConsoleHeight - 2, 11), gameLogConsoleWidht, gameLogConsoleHeight);
			gameLogConsole.Position = new Point (0, dungeonConsoleHeight + 1);
			statusConsole = new PartyStatusConsole (gameState.Party, statusConsoleWidth, statusConsoleHeight);
			statusConsole.Position = new Point (dungeonConsoleWidth + 1, 0);

			Add (dungeonFloorConsole);
			Add (gameLogConsole);
			Add (statusConsole);

			SetBackground (new Color (new Vector3 (0x12, 0x13, 0x14)));

			gameState.Dungeon.Update (gameState.Party, log);
			dungeonFloorConsole.Update ();
		}

		/// <summary>
		/// Called when the scene is paused.
		/// </summary>
		public override void OnPause ()
		{
			base.OnPause ();
		}

		/// <summary>
		/// Called when the scene is resumed.
		/// </summary>
		public override void OnResume ()
		{
			base.OnResume ();
		}

		/// <summary>
		/// Called when the scene is destroyed.
		/// </summary>
		public override void OnDestroy ()
		{
			base.OnDestroy ();
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
				//return new ExitAction (0);
				Director.Instance.PopScene ();
				return action;
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
			base.Update (delta);

			KeyboardState state = Keyboard.GetState ();
			IAction action = HandleInput ();

			if (action.Execute () && action is MoveAction)
				(new AndChain (new TryUseStairs (gameState, dungeonFloorConsole),
					new LogCurrentFloor (gameState, log))).Execute ();

			gameState.Dungeon.Update (gameState.Party, log);
		}
	}
}


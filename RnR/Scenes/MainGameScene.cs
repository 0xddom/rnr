using System;
using Lain.Views;
using RnR.Consoles;
using Lain;
using Microsoft.Xna.Framework;

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
	}
}


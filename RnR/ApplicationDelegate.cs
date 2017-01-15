using System;
using Lain;
using RnR.Scenes;

namespace RnR
{
	/// <summary>
	/// This class handles the initialization of the game.
	/// </summary>
	public class ApplicationDelegate
	{
		private const int WIDTH = 800;
		private const int HEIGHT = 600;

		/// <summary>
		/// Starts the game
		/// </summary>
		public void Run() {
			var unused = GameState.Instance; // Init instance

			var director = Director.Instance;
			//director.PushScene(new MainGameScene(), false);
			director.PushScene(new MainMenuScene(), false);
			//director.PushScene (new CombatScene (), false);
			var loop = new GameLoop(director, WIDTH, HEIGHT);
			loop.Run ();
		}
	}
}


using System;
using System.Collections.Generic;
using Lain;
using Lain.Views;
using Microsoft.Xna.Framework;
using RnR.Consoles;

namespace RnR.Scenes
{
	public class CombatScene : Scene
	{
		List<string> log;
		GameLogConsole logConsole;

		public override void OnCreate ()
		{
			var gameLogConsoleWidht = (int)Math.Floor (Configuration.GridWidth * 0.8);
			var gameLogConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 0.2);

			log = new List<string> ();

			logConsole = new GameLogConsole(log, Math.Min (gameLogConsoleHeight - 2, 11), gameLogConsoleWidht, gameLogConsoleHeight);
			logConsole.Position = new Point (0, (int)Math.Floor (Configuration.GridHeight * 0.8) + 1);
			Add (logConsole);

			SetBackground (new Color (new Vector3 (0x12, 0x13, 0x14)));
		}

		public override void OnDestroy ()
		{
		}

		public override void OnPause ()
		{
		}

		public override void OnResume ()
		{
		}

		public override void Update (GameTime delta)
		{
			base.Update (delta);
		}
	}
}

using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace RnR.Consoles
{
	/// <summary>
	/// This console prints the last lines of the log in each loop step.
	/// </summary>
	public class GameLogConsole : SadConsole.Consoles.Console
	{
		private int STARTX = 1;
		private int STARTY = 1;

		private List<string> log;
		private int lines;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RnR.Consoles.GameLogConsole"/> class.
		/// </summary>
		/// <param name="log">Log.</param>
		/// <param name="lines">Lines.</param>
		/// <param name="w">The width.</param>
		/// <param name="h">The height.</param>
		public GameLogConsole (List<string> log, int lines, int w, int h)
			: base (w, h)
		{
			this.log = log;
			this.lines = lines;
		}

		/// <summary>
		/// Writes a line.
		/// </summary>
		/// <param name="s">String.</param>
		private void WriteLine(string s) 
		{
			VirtualCursor.Print (s);
			VirtualCursor.Position = new Point (STARTX, VirtualCursor.Position.Y + 1);
		}

		/// <summary>
		/// Called during the update step in the game loop.
		/// </summary>
		public override void Update ()
		{
			Clear();
			VirtualCursor.Position = new Point(STARTX, STARTY);

			int start = Math.Max(0, log.Count - lines);
			for (int i = start; i < log.Count; i++) {
				WriteLine(log[i]);
			}
	
			base.Update ();
		}
	}
}


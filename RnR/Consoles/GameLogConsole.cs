using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace RnR.Consoles
{
	public class GameLogConsole : SadConsole.Consoles.Console
	{
		private int STARTX = 1;
		private int STARTY = 1;

		private List<string> log;
		private int lines;

		public GameLogConsole (List<string> log, int lines, int w, int h)
			: base (w, h)
		{
			this.log = log;
			this.lines = lines;
			//VirtualCursor.Print ("Hello World");
		}

		private void WriteLine(string s) 
		{
			VirtualCursor.Print (s);
			VirtualCursor.Position = new Point (STARTX, VirtualCursor.Position.Y + 1);
		}

		public override void Update ()
		{
			Clear();
			VirtualCursor.Position = new Point(STARTX, STARTY);

			//string[] visibleLog = new string[lines];

			int start = Math.Max(0, log.Count - lines);
			for (int i = start, j = 0; i < log.Count; i++, j++) {
				WriteLine(log[i]);
			}

			//WriteLine ("Test");
			//WriteLine ("TEXT");


			base.Update ();
		}
	}
}


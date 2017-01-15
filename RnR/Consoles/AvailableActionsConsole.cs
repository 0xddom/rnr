using System;
using System.Collections.Generic;

namespace RnR.Consoles
{
	public class AvailableActionsConsole : SadConsole.Consoles.Console
	{
		public List<string> availableActions { get; set; }

		public AvailableActionsConsole (int w)
			: base (w, 3)
		{
			availableActions = new List<string> ();
		}

		public override void Render ()
		{
			base.Render ();
			Clear ();

			var widthPerSection = (int)Math.Floor ((float)Width / availableActions.Count);

			for (int i = 0; i < availableActions.Count; i++) {
				VirtualCursor.Position = new Microsoft.Xna.Framework.Point (i * widthPerSection + 1, 1);
				VirtualCursor.Print (availableActions[i]);
			}
		}
	}
}

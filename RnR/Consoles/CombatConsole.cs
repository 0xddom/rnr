using System;
using RnR.Systems.D20;

namespace RnR.Consoles
{
	public class CombatConsole : SadConsole.Consoles.Console
	{
		public Combat Combat { get; set; }

		public CombatConsole (int w, int h)
			: base (w, h)
		{
		}

		private void UpdateCombatData ()
		{
		}

		/// <summary>
		/// Called during the update step in the game loop.
		/// </summary>
		public override void Update ()
		{
			base.Update ();
			UpdateCombatData ();
		}
	}
}

using System;
using RnR.Systems.D20;

namespace RnR.Consoles
{
	public abstract class AbstractCombatStatusConsole : SadConsole.Consoles.Console
	{
		public bool IsSelected { get; set; }
		public GameCharacter Character { get; private set;}
		protected const int STARTX = 1;
		protected const int STARTY = 1;


		protected AbstractCombatStatusConsole (GameCharacter character, int w, int h)
			: base (w, h)
		{
			this.Character = character;
			IsSelected = false;
		}

		// Template method
		protected abstract void RenderStatus ();

		public override void Render ()
		{
			base.Render ();
			RenderStatus ();
		}
	}
}

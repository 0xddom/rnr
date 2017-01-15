using System;
using System.Collections.Generic;
using Lain;
using Lain.Views;
using Microsoft.Xna.Framework.Input;
using RnR.Actions;
using RnR.Consoles;

namespace RnR.Scenes
{
	public class MainMenuScene : Scene
	{
		MenuConsole mainMenuConsole;

		int selectedItemIdx;
		bool itemSelected;
		KeyboardState lastKbState;
		List<MenuItem> menuItems;

		public override void OnCreate ()
		{
			base.OnCreate ();
			menuItems = new List<MenuItem>(new MenuItem [] { 
				new MenuItem(0, "New game", true),
				new MenuItem(1, "Exit", false)
			});

			mainMenuConsole = new MenuConsole (menuItems, Configuration.GridWidth, Configuration.GridHeight);
			Add (mainMenuConsole);

			selectedItemIdx = 0;
		}

		public override void OnDestroy ()
		{
			base.OnDestroy ();
		}

		public override void OnPause ()
		{
			base.OnPause ();
		}

		public override void OnResume ()
		{
			base.OnResume ();
		}

		public void HandleInput ()
		{
			KeyboardState ks = Keyboard.GetState ();

			if (ks.IsKeyDown (Keys.Down) &&
				!lastKbState.IsKeyDown (Keys.Down)) {
				// Go down
				selectedItemIdx++;
				if (selectedItemIdx >= menuItems.Count)
					selectedItemIdx = menuItems.Count - 1;
			} else if (ks.IsKeyDown (Keys.Up) &&
					   !lastKbState.IsKeyDown (Keys.Up)) {
				// Go up
				selectedItemIdx--;
				if (selectedItemIdx < 0)
					selectedItemIdx = 0;
			} else itemSelected |= ks.IsKeyDown (Keys.Enter);

			lastKbState = ks;
		}

		public override void Update (Microsoft.Xna.Framework.GameTime delta)
		{
			base.Update (delta);

			HandleInput ();

			for (int i = 0; i < menuItems.Count; i++)
				menuItems [i].Selected = i == selectedItemIdx;

			if (itemSelected) {
				switch (selectedItemIdx) {
				case 0:
					LoadNewGame ();
					break;
				case 1:
					(new ExitAction (0)).Execute ();
					break;
				}
			}
		}

		void LoadNewGame ()
		{
			itemSelected = false;
			Director.Instance.PushScene (new MainGameScene ());
		}
	}
}

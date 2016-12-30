using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;

namespace RnR
{
	public class GameLoop : Game
	{
		private GraphicsDeviceManager graphics;

		string[] FONTS = new string[] {"Cheepicus12", "IBM", "C64"};
		int WIDTH = 80;
		int HEIGHT = 25;

		public GameLoop ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Assets";

			System.Console.WriteLine (Environment.CurrentDirectory);
		}

		protected override void Initialize() 
		{
			IsFixedTimeStep = true;
			IsMouseVisible = false;

			var sadConsoleComponent = new SadConsole.EngineGameComponent (this, graphics, GetAvailableFont(), WIDTH, HEIGHT, () => {
				SadConsole.Engine.UseMouse = false;
				SadConsole.Engine.UseKeyboard = true;

				var defaultConsole = (SadConsole.Consoles.Console)SadConsole.Engine.ActiveConsole;

				defaultConsole.Print(2, 2, "Hello world");
			});

			Components.Add (sadConsoleComponent);

			base.Initialize ();
		}

		protected override void Update(GameTime delta)
		{
			base.Update (delta);
		}

		protected override void Draw(GameTime delta)
		{
			base.Draw (delta);
		}

		/// <summary>
		/// Search for fonts and returns the first one found.
		/// In case no font is found. Aborts the execution and exits the program.
		/// </summary>
		/// <returns>The available font.</returns>
		private string GetAvailableFont() {
			string availableFont = (new List<string> (FONTS))
				.ConvertAll<string> ((font) => string.Format ("{0}.font", font))
				.Find ((fontFile) => File.Exists(fontFile));

			if (availableFont != null) {
				return availableFont;
			} else {
				System.Console.WriteLine ("Font not found");
				Environment.Exit (1);
				return null;
			}
		}
	}
}


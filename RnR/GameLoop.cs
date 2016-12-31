using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace RnR
{
	public class GameLoop : Game
	{
		private GraphicsDeviceManager graphics;
		private Director director;

		string[] FONTS = new string[] { "Cheepicus12", "IBM", "C64" };
		//int WIDTH = 80;
		//int HEIGHT = 25;

		private Font font;

		public GameLoop ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Assets";

			System.Console.WriteLine (Environment.CurrentDirectory);

			font = GetAvailableFont ();
		}

		protected override void Initialize ()
		{
			IsFixedTimeStep = true;
			IsMouseVisible = false;

			var sadConsoleComponent = new SadConsole.EngineGameComponent (this, graphics, font.Path, GridWidth, GridHeight, () => {
				SadConsole.Engine.UseMouse = false;
				SadConsole.Engine.UseKeyboard = true;

				director = Director.Instance;
				// Setup boot scene.

				var defaultConsole = (SadConsole.Consoles.Console)SadConsole.Engine.ActiveConsole;

				defaultConsole.Print (2, 2, "Hello world");
			});

			Components.Add (sadConsoleComponent);

			base.Initialize ();
		}

		protected override void Update (GameTime delta)
		{
			director.UpdateCurrentScene (delta);
			base.Update (delta);
		}

		protected override void Draw (GameTime delta)
		{
			director.DrawCurrentScene (delta);
			base.Draw (delta);
		}

		private int DisplayWidth {
			get {
				return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			}
		}

		private int DisplayHeight {
			get { 
				return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			}
		}

		private int GridWidth {
			get { return DisplayWidth / font.GlyphWidth; }
		}

		private int GridHeight {
			get { return DisplayHeight / font.GlyphHeight; }
		}

		/// <summary>
		/// Search for fonts and returns the first one found.
		/// In case no font is found. Aborts the execution and exits the program.
		/// </summary>
		/// <returns>The available font.</returns>
		private Font GetAvailableFont ()
		{
			Font availableFont = (new List<string> (FONTS))
				.ConvertAll<Font> ((font) => new Font(string.Format ("{0}.font", font)))
				.Find ((font) => File.Exists (font.Path));

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


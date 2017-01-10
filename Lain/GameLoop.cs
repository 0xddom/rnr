using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Lain.Views;

namespace Lain
{
	public class GameLoop : Game, IMessageReceiver
	{
		private GraphicsDeviceManager graphics;

		private Director director;
		private Color background;

		private FrameCounter frameCounter = new FrameCounter();

		public GameLoop (Director director)
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Assets";

			//System.Console.WriteLine (Environment.CurrentDirectory);

			this.director = director;
			director.AddReceiver (this);
		}

		protected override void Initialize ()
		{
			IsFixedTimeStep = true;
			IsMouseVisible = false;

			var sadConsoleComponent = new SadConsole.EngineGameComponent (this, graphics, Configuration.Font.Path, Configuration.GridWidth, Configuration.GridHeight, () => {
				SadConsole.Engine.UseMouse = false;
				SadConsole.Engine.UseKeyboard = true;
			});

			Components.Add (sadConsoleComponent);

			base.Initialize ();
		}

		protected override void Update (GameTime delta)
		{
			GraphicsDevice.Clear (background);

			director.Update (delta);
			base.Update (delta);
		}

		protected override void Draw (GameTime delta)
		{
			var deltaTime = (float)delta.ElapsedGameTime.TotalSeconds;

			frameCounter.Update(deltaTime);
			//System.Console.WriteLine ("FPS: " + frameCounter.AverageFramesPerSecond);

			director.Draw (delta);
			base.Draw (delta);
		}

		#region IMessageReceiver implementation

		public bool ReceiveMessage (Message message, object[] data)
		{
			switch (message) {
			case Message.SetBackground:
				SetBackground ((Color)data [0]);
				return true;
			}

			return false;
		}

		#endregion

		void SetBackground (Color color)
		{
			background = color;
		}

		public void AddReceiver (IMessageReceiver receiver)
		{
		}
	}
}


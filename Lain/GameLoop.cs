using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lain
{
	/// <summary>
	/// Game loop.
	/// 
	/// This class is in charge of initialization of the resources of the game and the update cycle (aka game loop).
	/// </summary>
	public class GameLoop : Game, IMessageReceiver
	{
		/// <summary>
		/// The graphics manager.
		/// 
		/// MonoGame dependency
		/// </summary>
		private GraphicsDeviceManager graphics;

		/// <summary>
		/// The director.
		/// </summary>
		private Director director;

		/// <summary>
		/// The background color.
		/// </summary>
		private Color background;

		/// <summary>
		/// The frame counter.
		/// </summary>
		private FrameCounter frameCounter = new FrameCounter ();

		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.GameLoop"/> class.
		/// </summary>
		/// <param name="director">The director for the components tree.</param>
		public GameLoop (Director director, int w, int h)
		{
			graphics = new GraphicsDeviceManager (this);
			graphics.PreferredBackBufferHeight = h;
			graphics.PreferredBackBufferWidth = w;
			Window.IsBorderless = true;
			Content.RootDirectory = "Assets";

			this.director = director;
			director.AddReceiver (this);
		}

		/// <summary>
		/// Initialize the game resources and libraries.
		/// </summary>
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

		/// <summary>
		/// Update to the specified delta.
		/// </summary>
		/// <param name="delta">Delta.</param>
		protected override void Update (GameTime delta)
		{
			director.Update (delta);
			base.Update (delta);
		}

		/// <summary>
		/// Draw to the specified delta.
		/// </summary>
		/// <param name="delta">Delta.</param>
		protected override void Draw (GameTime delta)
		{
			var deltaTime = (float)delta.ElapsedGameTime.TotalSeconds;

			frameCounter.Update (deltaTime);

			GraphicsDevice.Clear (background);

			director.Draw (delta);
			base.Draw (delta);
		}

		#region IMessageReceiver implementation

		/// <summary>
		/// Receives the message. Only responds to SetBackground.
		/// </summary>
		/// <returns><c>true</c>, if message was received and was SetBackground, <c>false</c> otherwise.</returns>
		/// <param name="message">Message.</param>
		/// <param name="data">Data.</param>
		public bool ReceiveMessage (Message message, object [] data)
		{
			switch (message) {
			case Message.SetBackground:
				SetBackground ((Color)data [0]);
				return true;
			}

			return false;
		}

		#endregion

		/// <summary>
		/// Sets the background color.
		/// </summary>
		/// <param name="color">Color.</param>
		void SetBackground (Color color)
		{
			background = color;
		}

		/// <summary>
		/// This class can't send messages.
		/// </summary>
		/// <param name="receiver">Receiver.</param>
		public void AddReceiver (IMessageReceiver receiver)
		{
		}
	}
}


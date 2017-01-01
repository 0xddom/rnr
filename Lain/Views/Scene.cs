using SadConsole.Consoles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Lain.Views
{
	public abstract class Scene : IScene
	{
		public Scene ()
		{
			consoles = new ConsoleList();
			//SadConsole.Engine.ConsoleRenderStack = consoles;
			nodes = new List<INode> ();
		}

		private ConsoleList consoles;
		private List<INode> nodes;

		#region INode implementation

		public void Update (Microsoft.Xna.Framework.GameTime delta)
		{
			nodes.ForEach ((node) => node.Update (delta));
		}

		public void Draw (Microsoft.Xna.Framework.GameTime delta)
		{
			
			nodes.ForEach ((node) => node.Draw (delta));
		}

		#endregion

		protected void Add(INode node) {
			if(!(node is IScene)) // A scene can't hold another scenes.
				nodes.Add (node);
		}

		protected void Add(SadConsole.Consoles.Console console) {
			consoles.Add (console);
			SadConsole.Engine.ConsoleRenderStack = consoles;
		}

		protected void SetBackground(Color color) 
		{
			object oColor = (object)color;
			if(receiver != null)
				receiver.ReceiveMessage (Message.SetBackground, new object[] { oColor });
		}

		public abstract void OnCreate ();
		public abstract void OnPause ();
		public abstract void OnResume ();
		public abstract void OnDestroy ();

		public bool ReceiveMessage (Message message, object[] data)
		{
			return false;
		}

		private IMessageReceiver receiver;

		public void AddReceiver (IMessageReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}


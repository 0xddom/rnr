﻿using SadConsole.Consoles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace Lain.Views
{
	/// <summary>
	/// Abstract class that implements all the common functionality of the scenes API.
	/// </summary>
	public abstract class Scene : IScene
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Views.Scene"/> class.
		/// </summary>
		public Scene ()
		{
			consoles = new ConsoleList();
			//SadConsole.Engine.ConsoleRenderStack = consoles;
			nodes = new List<INode> ();
			savedConsoles = new List<string> ();
			savedConsolesToFile = false;
		}

		/// <summary>
		/// The consoles of SadConsole have to be in a list of consoles.
		/// </summary>
		private ConsoleList consoles;

		/// <summary>
		/// The child nodes.
		/// </summary>
		private List<INode> nodes;

		private List<string> savedConsoles;
		private bool savedConsolesToFile;

		#region INode implementation

		/// <summary>
		/// Called during the update step in the game loop.
		/// 
		/// Simply iterate over the child and call Update on them.
		/// </summary>
		/// <param name="delta">Delta time.</param>
		public virtual void Update (Microsoft.Xna.Framework.GameTime delta)
		{
			nodes.ForEach ((node) => node.Update (delta));
		}

		/// <summary>
		/// Called during the draw step in the game loop.
		/// 
		/// Simply iterate over the child and call Draw on them.
		/// </summary>
		/// <param name="delta">Delta time.</param>
		public virtual void Draw (Microsoft.Xna.Framework.GameTime delta)
		{
			
			nodes.ForEach ((node) => node.Draw (delta));
		}

		#endregion

		/// <summary>
		/// Add a node to the children node list.
		/// </summary>
		/// <param name="node">The new node.</param>
		protected void Add(INode node) {
			if(!(node is IScene)) // A scene can't hold another scenes.
				nodes.Add (node);
		}

		/// <summary>
		/// Adds a console to the consoles list and sets the console render stack
		/// </summary>
		/// <param name="console">The new console.</param>
		protected void Add(SadConsole.Consoles.Console console) {
			consoles.Add (console);
			SadConsole.Engine.ConsoleRenderStack = consoles;
		}

		/// <summary>
		/// Sets the background color of the screen.
		/// 
		/// The action gets propagated to the parent because scenes can't set these properties.
		/// </summary>
		/// <param name="color">The backgournd color.</param>
		protected void SetBackground(Color color) 
		{
			object oColor = (object)color;
			if(receiver != null)
				receiver.ReceiveMessage (Message.SetBackground, new object[] { oColor });
		}

		/// <summary>
		/// Called when the scene is created.
		/// </summary>
		public virtual void OnCreate ()
		{ 
			System.Console.WriteLine ($"{this.GetType ().Name}::OnCreate");
		}

		/// <summary>
		/// Called when the scene is paused.
		/// </summary>
		public virtual void OnPause ()
		{
			System.Console.WriteLine ($"{this.GetType ().Name}::OnPause");

			/*var tmp = System.IO.Path.GetTempPath ();
			System.Console.WriteLine ($"[{this.GetType ().Name}] Saving the scene consoles to {tmp}");

			int i = 1;
			savedConsoles.Clear ();
			foreach (SadConsole.Consoles.Console c in consoles) {
				var fileName = string.Format ("{1}_{0}.console", i, GetType ().Name);
				c.Save (System.IO.Path.Combine (tmp, fileName), true, c.GetType());
				savedConsoles.Add(System.IO.Path.Combine (tmp, fileName));
				i++;
			}
			savedConsolesToFile = true;*/
			SadConsole.Engine.ConsoleRenderStack = new ConsoleList ();
		}

		/// <summary>
		/// Called when the scene is resumed.
		/// </summary>
		public virtual void OnResume ()
		{
			System.Console.WriteLine ($"{this.GetType ().Name}::OnResume");

			if (savedConsolesToFile) {
				System.Console.WriteLine ($"[{this.GetType ().Name}] Loading the scene consoles");
				consoles = new ConsoleList ();
				foreach (var path in savedConsoles) {
					consoles.Add (SadConsole.Consoles.Console.Load (path));
					System.IO.File.Delete (path);
				}
				SadConsole.Engine.ConsoleRenderStack = consoles;
			} else {
				SadConsole.Engine.ConsoleRenderStack = consoles;
			}
		}

		/// <summary>
		/// Called when the scene is destroyed and not needed anymore.
		/// </summary>
		public virtual void OnDestroy ()
		{
			System.Console.WriteLine ($"{this.GetType ().Name}::OnDestroy");

			if (savedConsolesToFile) {
				foreach (var path in savedConsoles) {
					System.IO.File.Delete (path);
				}
				savedConsolesToFile = false;
			}	
		}

		/// <summary>
		/// Receives a message. This class don't accept any messages. So false is always returned
		/// </summary>
		/// <returns>Always false.</returns>
		/// <param name="message">Message type.</param>
		/// <param name="data">Message data.</param>
		public bool ReceiveMessage (Message message, object[] data)
		{
			return false;
		}

		/// <summary>
		/// The parent to whom send messages.
		/// </summary>
		private IMessageReceiver receiver;

		/// <summary>
		/// Sets the receiver. This class only can have a receiver. which asumes is its parent in the component tree.
		/// </summary>
		/// <param name="receiver">The receiver.</param>
		public void AddReceiver (IMessageReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}


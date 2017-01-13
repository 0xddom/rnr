using System;
using Microsoft.Xna.Framework;
using Lain.Views;
using Lain.Utils;

namespace Lain
{
	/// <summary>
	/// Manages the scenes live cycles and serves as the root of the components tree.ç
	/// 
	/// This class is a Singleton.
	/// </summary>
	public class Director : INode
	{
		#region Singleton
		/// <summary>
		/// The singleton instance.
		/// </summary>
		private static Director instance = null;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static Director Instance {
			get {
				if (instance == null) instance = new Director ();
				return instance;
			}
		}
		#endregion

		/// <summary>
		/// A struct for storing metadata about the scenes
		/// </summary>
		class SceneStackElement {
			public IScene Scene { get; set; }
			public bool Created { get; set; }
		}

		/// <summary>
		/// The scene stack.
		/// </summary>
		private Stack<SceneStackElement> sceneStack;

		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Director"/> class.
		/// </summary>
		public Director ()
		{
			sceneStack = new Stack<SceneStackElement> ();
		}

		/// <summary>
		/// Gets the current scene. If the scene was not initialized is initialized now.
		/// </summary>
		/// <value>The current scene.</value>
		public IScene CurrentScene {
			get {
				try {
					var sceneNode = sceneStack.Peek ();

					if (!sceneNode.Created) {
						sceneNode.Scene.OnCreate ();
						sceneNode.Scene.OnResume ();
						sceneNode.Created = true;
					}
					return sceneNode.Scene;
				} catch(InvalidOperationException) {
					return NullScene.Instance;
				}
			}
		}

		#region INode implementation

		/// <summary>
		/// Called during the update step in the game loop.
		/// 
		/// Sends the same message to the current scene.
		/// </summary>
		/// <param name="delta">Delta time.</param>
		public void Update (GameTime delta)
		{
			CurrentScene.Update (delta);
		}

		/// <summary>
		/// Called during the draw step in the game loop.
		/// 
		/// Sends the same message to the current scene.
		/// </summary>
		/// <param name="delta">Delta time.</param>
		public void Draw (GameTime delta)
		{
			CurrentScene.Draw (delta);
		}

		#endregion

		/// <summary>
		/// Pushs a scene to the stack and initialize it.
		/// </summary>
		/// <param name="scene">Scene.</param>
		public void PushScene(IScene scene) {
			PushScene (scene, true);
		}
			
		/// <summary>
		/// Pushs a scene to the stack.
		/// </summary>
		/// <param name="scene">Scene.</param>
		/// <param name="create">If set to <c>true</c> initialize it.</param>
		public void PushScene(IScene scene, bool create) {
			var sceneNode = new SceneStackElement();

			if (create) {
				scene.OnCreate ();
				scene.OnResume ();
			}
			sceneNode.Scene = scene;
			sceneNode.Created = create;

			if(CurrentSceneWasCreated) CurrentScene.OnPause ();

			sceneStack.Push (sceneNode);
		}

		/// <summary>
		/// Pops the scene and send the destroy messages.
		/// </summary>
		public void PopScene() {
			if (CurrentSceneWasCreated) {
				CurrentScene.OnPause ();
				CurrentScene.OnDestroy ();
			}
			sceneStack.Pop ();

			if (CurrentSceneWasCreated) {
				CurrentScene.OnResume ();
			}
		}

		/// <summary>
		/// Switchs the current scene with a new scene. Destroying the older one. The new scene is initialized.
		/// </summary>
		/// <param name="scene">Scene.</param>
		public void SwitchScene(IScene scene) {
			SwitchScene (scene, true);
		}

		/// <summary>
		/// Switchs the current scene with a new scene. Destroying the older one.
		/// </summary>
		/// <param name="scene">Scene.</param>
		/// <param name="create">If set to <c>true</c> initialize the new scene.</param>
		public void SwitchScene(IScene scene, bool create) {
			if (CurrentSceneWasCreated) {
				CurrentScene.OnPause ();
				CurrentScene.OnDestroy ();
			}
			sceneStack.Pop ();
			
			var sceneNode = new SceneStackElement();

			if (create) {
				scene.OnCreate ();
				scene.OnResume ();
			}
			scene.AddReceiver (this);
			sceneNode.Scene = scene;
			sceneNode.Created = create;

			sceneStack.Push (sceneNode);
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="Lain.Director"/> current scene was created.
		/// </summary>
		/// <value><c>true</c> if current scene was created; otherwise, <c>false</c>.</value>
		private bool CurrentSceneWasCreated {
			get { return (!sceneStack.Empty()) && sceneStack.Peek ().Created; }
		}

		/// <summary>
		/// Receives a message.
		/// 
		/// If the message is SetBackground, forward it to the receiver, otherwise fail.
		/// </summary>
		/// <returns><c>true</c>, if message was received and was SetBackgournd, <c>false</c> otherwise.</returns>
		/// <param name="message">Message type.</param>
		/// <param name="data">Message data.</param>
		public bool ReceiveMessage (Message message, object[] data)
		{
			switch (message) {
			case Message.SetBackground:
				return receiver.ReceiveMessage (message, data);
			}
			return false;
		}

		/// <summary>
		/// The receiver.
		/// </summary>
		private IMessageReceiver receiver;

		/// <summary>
		/// Sets the receiver. This class canonyl have one receiver.
		/// </summary>
		/// <param name="receiver">Receiver.</param>
		public void AddReceiver (IMessageReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}


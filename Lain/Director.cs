using System;
using Microsoft.Xna.Framework;
using Lain.Views;
using Lain.Utils;

namespace Lain
{
	public class Director : INode
	{
		#region Singleton
		private static Director instance = null;

		public static Director Instance {
			get {
				if (instance == null) instance = new Director ();
				return instance;
			}
		}
		#endregion

		class SceneStackElement {
			public IScene Scene { get; set; }
			public bool Created { get; set; }
		}

		private Stack<SceneStackElement> sceneStack;

		public Director ()
		{
			sceneStack = new Stack<SceneStackElement> ();
		}

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

		public void Update (GameTime delta)
		{
			CurrentScene.Update (delta);
		}

		public void Draw (GameTime delta)
		{
			CurrentScene.Draw (delta);
		}

		#endregion

		public void PushScene(IScene scene) {
			PushScene (scene, true);
		}
			
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

		public void SwitchScene(IScene scene) {
			SwitchScene (scene, true);
		}

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

		private bool CurrentSceneWasCreated {
			get { return (!sceneStack.Empty()) && sceneStack.Peek ().Created; }
		}

		public bool ReceiveMessage (Message message, object[] data)
		{
			switch (message) {
			case Message.SetBackground:
				return receiver.ReceiveMessage (message, data);
			}
			return false;
		}

		private IMessageReceiver receiver;

		public void AddReceiver (IMessageReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}


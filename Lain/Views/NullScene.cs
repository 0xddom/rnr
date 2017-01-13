using System;

namespace Lain.Views
{
	/// <summary>
	/// Represents a scene that does nothing nor draws anything.
	/// 
	/// This class is a Singleton.
	/// </summary>
	public class NullScene : Scene
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Lain.Views.NullScene"/> class.
		/// </summary>
		public NullScene ()
		{
		}

		#region Singleton

		/// <summary>
		/// The singleton instance.
		/// </summary>
		private static NullScene instance = null;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static NullScene Instance {
			get {
				if (instance == null)
					instance = new NullScene ();
				return instance;
			}
		}
		#endregion

		#region IScene implementation

		/// <summary>
		/// Called when the scene is created.
		/// 
		/// This method is empty.
		/// </summary>
		public override void OnCreate ()
		{
		}

		/// <summary>
		/// Called when the scene is paused.
		/// 
		/// This method is empty.
		/// </summary>
		public override void OnPause ()
		{
		}

		/// <summary>
		/// Called when the scene is resumed.
		/// 
		/// This method is empty.
		/// </summary>
		public override void OnResume ()
		{
		}

		/// <summary>
		/// Called when the scene is destroyed and not needed anymore.
		/// 
		/// This method is empty.
		/// </summary>
		public override void OnDestroy ()
		{
		}

		#endregion
	}
}


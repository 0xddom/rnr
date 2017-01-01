using System;

namespace Lain.Views
{
	public class NullScene : Scene
	{
		public NullScene ()
		{
		}

		#region Singleton
		private static NullScene instance = null;

		public static NullScene Instance {
			get {
				if (instance == null)
					instance = new NullScene ();
				return instance;
			}
		}
		#endregion

		#region IScene implementation

		public override void OnCreate ()
		{
		}

		public override void OnPause ()
		{
		}

		public override void OnResume ()
		{
		}

		public override void OnDestroy ()
		{
		}

		#endregion
	}
}


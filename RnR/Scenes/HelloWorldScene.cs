using System;
using Lain.Views;
using RnR.Consoles;

namespace RnR.Scenes
{
	public class HelloWorldScene : Scene
	{
		public HelloWorldScene ()
		{
		}

		HelloWorldConsole hwc;

		#region IScene implementation

		public override void OnCreate ()
		{
			hwc = new HelloWorldConsole ();
			Add (hwc);
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


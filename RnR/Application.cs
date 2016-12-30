using System;
namespace RnR
{
	public class Application
	{
		public static void Main(string[] args)
		{
#if !MACOS
			ApplicationDelegate app = new ApplicationDelegate();
			app.Run ();
#else
			NSApplication.Init ();
			using (var p = new NSAutoreleasePool ()) {
				NSApplication.SharedApplication.Delegate = new ApplicationDelegate ();
				NSApplication.Main (args);
			}
#endif
		}
	}
}

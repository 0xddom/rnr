using System;

namespace RnR
{
	/// <summary>
	/// This class handles the initialization of the game.
	/// Dependending of the compilation target, initilization is handled
	/// diferently.
	/// </summary>
#if MACOS
	public class ApplicationDelegate : NSApplicationDelegate
#else
	public class ApplicationDelegate
#endif
	{
		public ApplicationDelegate ()
		{
		}

#if MACOS
		public override void FinishedLaunching(MonoMac.Foundation.NSObject notification) {
			Run();
		}

		public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender) {
			return true;
		}
#endif

		public void Run() {
		}
	}
}


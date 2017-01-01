using SadConsole.Consoles;

namespace RnR.Consoles
{
	public class HelloWorldConsole : Console
	{
		public HelloWorldConsole () : base(40,40)
		{
			//IsVisible = false;
			Print (2, 2, "Hello World");
		}
	}
}


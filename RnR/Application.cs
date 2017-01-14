using System;
namespace RnR
{
	/// <summary>
	/// Application entry point.
	/// </summary>
	public class Application
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			var app = new ApplicationDelegate();
			app.Run ();
		}
	}
}

using System;
using Microsoft.Xna.Framework;

namespace RnR
{
	public class Director
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


		public Director ()
		{
		}

		public void UpdateCurrentScene(GameTime delta) {
			System.Console.WriteLine ("Updating");
		}

		public void DrawCurrentScene(GameTime delta) {
			System.Console.WriteLine ("Drawing");
		}
	}
}


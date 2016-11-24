using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public class PlayerGameActor : AbstractGameActor
	{
		private int hunger;
		private int level;

		public PlayerGameActor ()
		{
		}

		public int Hunger { 
			get { return hunger; } 
			set { 
				hunger = Math.Max(0, Math.Min(value, MaxHunger)); 
			} 
		}

		public int MaxHunger {
			get {
				return attributes [Attributes.CON].Mod * 10;
			}
		}
	}
}

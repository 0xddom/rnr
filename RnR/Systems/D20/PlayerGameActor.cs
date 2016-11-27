using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public class PlayerGameActor : AbstractGameActor
	{
		private int hunger;
		private int level;

		public PlayerGameActor (int str, int dex, int con, int _int, int wis, int cha) 
			: base (str, dex, con, _int, wis, cha)
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
				return CON().Mod * 10;
			}
		}
	}
}

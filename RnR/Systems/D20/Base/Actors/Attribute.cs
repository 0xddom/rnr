using System;
namespace RnR.Systems.D20.Base.Actors
{
	public class Attribute
	{
		private int value;
		private Attributes type;

		public Attribute (int value, Attributes type)
		{
			this.value = value;
			this.type = type;
		}

		public Attribute () {}

		public int Value { get { return this.value; } set { this.value = value; } }
		public int Mod { get { return (this.value / 2) - 5; } }
		public Attributes Type { get { return this.type; } }

	}
}

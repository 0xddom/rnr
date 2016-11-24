using System;
using System.Collections.Generic;

namespace RnR.Systems.D20.Base.Actors
{
	public abstract class AbstractGameActor
	{
		#region Class attributes

		protected readonly string name;
		protected int money;
		protected int hitPoints;
		protected int maxHitPoints;
		protected Dictionary<Attributes, Attribute> attributes;
		protected TrapEffect activeTrapEffects;

		#endregion

		public AbstractGameActor ()
		{
		}

		#region Getter & Setters

		public int STR { get { return attributes [Attributes.STR].Value; } }
		public int CON { get { return attributes [Attributes.CON].Value; } }
		public int DEX { get { return attributes [Attributes.DEX].Value; } }
		public int INT { get { return attributes [Attributes.INT].Value; } }
		public int WIS { get { return attributes [Attributes.WIS].Value; } }
		public int CHA { get { return attributes [Attributes.CHA].Value; } }

		public string Name { get { return name; } }
		public int Money { get { return money; } set { this.money = value; } }
		public int HitPoints {
			get { return hitPoints; }
			set {
				Math.Max (0, Math.Min (value, maxHitPoints));
			}
		}

		#endregion
	}
}

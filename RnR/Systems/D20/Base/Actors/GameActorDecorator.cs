using System;
namespace RnR.Systems.D20.Base.Actors
{
	public abstract class GameActorDecorator : GameActor
	{
		protected GameActor target;

		public GameActorDecorator (GameActor target)
		{
			this.target = target;
		}

		public GameActor Target {
			get {
				return target;
			}
			set {
				target = value;
			}
		}

		// By default there is no effect
		public Attribute CHA {
			get {
				return target.CHA;
			}
		}

		public Attribute CON {
			get {
				return target.CON;
			}
		}

		public Attribute DEX {
			get {
				return target.DEX;
			}
		}

		public int HitPoints {
			get {
				return target.HitPoints;
			}

			set {
				target.HitPoints = value;
			}
		}

		public Attribute INT {
			get {
				return target.INT;
			}
		}

		public int MaxHitPoints {
			get {
				return target.MaxHitPoints;
			}
		}

		public int Money {
			get {
				return target.Money;
			}

			set {
				target.Money = value;
			}
		}

		public Attribute STR {
			get {
				return target.STR;
			}
		}

		public Attribute WIS {
			get {
				return target.WIS;
			}
		}

		public Skill GetSkill (SkillType type)
		{
			return target.GetSkill (type);
		}
	}
}

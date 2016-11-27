using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

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

		public AbstractAmmo EquipedAmmo {
			get {
				return target.EquipedAmmo;
			}

			set {
				target.EquipedAmmo = value;
			}
		}

		public AbstractWeapon EquipedWeapon {
			get {
				return target.EquipedWeapon;
			}

			set {
				target.EquipedWeapon = value;
			}
		}

		public AbstractArmor EquipedArmor {
			get {
				return target.EquipedArmor;
			}

			set {
				target.EquipedArmor = value;
			}
		}

		public AbstractRing EquipedRing {
			get {
				return target.EquipedRing;
			}

			set {
				target.EquipedRing = value;
			}
		}

		public AbstractEarring EquipedEarring {
			get {
				return target.EquipedEarring;
			}

			set {
				target.EquipedEarring = value;
			}
		}

		public AbstractNecklace EquipedNecklace {
			get {
				return target.EquipedNecklace;
			}

			set {
				target.EquipedNecklace = value;
			}
		}

		public List<GameObject> Inventory {
			get {
				return target.Inventory;
			}
		}

		public Skill GetSkill (SkillType type)
		{
			return target.GetSkill (type);
		}
	}
}

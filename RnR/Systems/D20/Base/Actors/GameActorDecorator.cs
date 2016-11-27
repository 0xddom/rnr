using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Base.Actors
{
	public abstract class GameActorDecorator : GameActor
	{
		public static void Remove (GameActor target, GameActorDecorator decorator)
		{
			if (target is GameActorDecorator) {
				var i = target;
				while (i != null && i is GameActorDecorator && (i as GameActorDecorator).Target != decorator) {
					i = (i as GameActorDecorator).Target;
				}
				(i as GameActorDecorator).Target = ((i as GameActorDecorator).Target as GameActorDecorator).Target;
			}
		}

		protected GameActor target;

		public GameActorDecorator (GameActor target)
		{
			this.target = target;
		}

		public GameActorDecorator () : this(null)
		{
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
		public virtual Attribute CHA() {
			//get {
				return target.CHA();
			//}
		}

		public virtual Attribute CON() {
			//get {
				return target.CON();
			//}
		}

		public virtual Attribute DEX() {
			//get {
				return target.DEX();
			//}
		}

		public int HitPoints {
			get {
				return target.HitPoints;
			}

			set {
				target.HitPoints = value;
			}
		}

		public virtual Attribute INT() {
			//get {
			return target.INT();
			//}
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

		public virtual Attribute STR() {
			//get {
			return target.STR();
			//}
		}

		public virtual Attribute WIS() {
			//get {
			return target.WIS();
			//}
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
			Skill s = target.GetSkill (type).Clone ();
			switch (s.AttributeType) {
			case Attributes.CHA:
				s.Attribute = CHA ();
				break;
			case Attributes.CON:
				s.Attribute = CON ();
				break;
			case Attributes.DEX:
				s.Attribute = DEX ();
				break;
			case Attributes.INT:
				s.Attribute = INT ();
				break;
			case Attributes.STR:
				s.Attribute = STR ();
				break;
			case Attributes.WIS:
				s.Attribute = WIS ();
				break;
			}
			return s;
		}

		public GameActor Equip (EquipableObject obj)
		{
			return target.Equip (obj);
		}
	}
}

using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Base.Actors
{
	public abstract class AbstractGameActor : GameActor
	{
		#region Class attributes

		protected readonly string name;
		protected int money;
		protected int hitPoints;
		protected int maxHitPoints;
		protected Dictionary<SkillType, Skill> skills;

		protected Attribute _STR, _DEX, _CON, _INT, _WIS, _CHA;

		protected AbstractRing equipedRing;
		protected AbstractAmmo equipedAmmo;
		protected AbstractArmor equipedArmor;
		protected AbstractWeapon equipedWeapon;
		protected AbstractNecklace equipedNecklace;
		protected AbstractEarring equipedEarring;

		protected List<GameObject> inventory;

		#endregion

		public AbstractGameActor ()
		{
			skills = new Dictionary<SkillType, Skill> ();
			inventory = new List<GameObject> ();
			equipedAmmo = null;
			equipedRing = null;
			equipedArmor = null;
			equipedWeapon = null;
			equipedEarring = null;
			equipedNecklace = null;
		}

		/// <summary>
		/// Initializes an instance with only the 6 basic attributes
		/// </summary>
		/// <param name="str">STR</param>
		/// <param name="dex">DEX</param>
		/// <param name="con">CON</param>
		/// <param name="_int">INT</param>
		/// <param name="wis">WIS</param>
		/// <param name="cha">CHA</param>
		public AbstractGameActor (int str, int dex, int con, int _int, int wis, int cha) : this()
		{
			_STR = new Attribute (str, Attributes.STR);
			_DEX = new Attribute (dex, Attributes.DEX);
			_CON = new Attribute (con, Attributes.CON);
			_INT = new Attribute (_int, Attributes.INT);
			_WIS = new Attribute (wis, Attributes.WIS);
			_CHA = new Attribute (cha, Attributes.CHA);
		}

		#region Getter & Setters

		public Attribute STR() { /*get {*/ return _STR; } //}
		public Attribute CON() { /*get {*/ return _CON; } //}
		public Attribute DEX() { /*get {*/ return _DEX; } //}
		public Attribute INT() {/* get {*/ return _INT; } //}
		public Attribute WIS() { /*get {*/ return _WIS; } //}
		public Attribute CHA() { /*get {*/ return _CHA; } //}

		public string Name { get { return name; } }
		public int Money { get { return money; } set { money = value; } }
		public int HitPoints {
			get { return hitPoints; }
			set {
				hitPoints = Math.Max (0, Math.Min (value, MaxHitPoints));
			}
		}
		public int MaxHitPoints { get { return maxHitPoints; } }

		public AbstractAmmo EquipedAmmo {
			get {
				return equipedAmmo;
			}
			set {
				equipedAmmo = value;
			}
		}

		public AbstractWeapon EquipedWeapon {
			get {
				return equipedWeapon;
			}
			set {
				equipedWeapon = value;
			}
		}

		public AbstractArmor EquipedArmor {
			get {
				return equipedArmor;
			}
			set {
				equipedArmor = value;
			}
		}

		public AbstractRing EquipedRing {
			get {
				return equipedRing;
			}

			set {
				equipedRing = value;
			}
		}

		public AbstractEarring EquipedEarring {
			get {
				return equipedEarring;
			}

			set {
				equipedEarring = value;
			}
		}

		public AbstractNecklace EquipedNecklace {
			get {
				return equipedNecklace;
			}

			set {
				equipedNecklace = value;
			}
		}

		public List<GameObject> Inventory {
			get {
				return inventory;
			}
		}

		#endregion

		public bool IsDead () { return hitPoints == 0; }

		public Skill GetSkill (SkillType type)
		{
			if (skills.ContainsKey (type)) return skills [type];
			throw new CantParticipateInContestException (this);
		}

		public GameActor Equip (EquipableObject obj)
		{
			GameActor self = this;
			return obj.OnEquip (self);
		}
	}
}

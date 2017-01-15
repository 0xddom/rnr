using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Base.Actors
{
	public class GameActor : IGameActor
	{
		#region Class attributes

		protected readonly string name;
		protected int money;
		protected int hitPoints;
		public Dictionary<SkillType, Skill> Skills { get; private set; }
		protected int hunger;

		protected Attribute _STR, _DEX, _CON, _INT, _WIS, _CHA;

		protected AbstractRing equipedRing;
		protected AbstractArmor equipedArmor;
		protected AbstractWeapon equipedWeapon;
		protected AbstractNecklace equipedNecklace;
		protected AbstractEarring equipedEarring;

		#endregion

		public GameActor ()
		{
			Skills = new Dictionary<SkillType, Skill> ();
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
		public GameActor (int str, int dex, int con, int _int, int wis, int cha) : this()
		{
			_STR = new Attribute (str, Attributes.STR);
			_DEX = new Attribute (dex, Attributes.DEX);
			_CON = new Attribute (con, Attributes.CON);
			_INT = new Attribute (_int, Attributes.INT);
			_WIS = new Attribute (wis, Attributes.WIS);
			_CHA = new Attribute (cha, Attributes.CHA);

			hitPoints = MaxHitPoints;
			hunger = MaxHunger;
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
		public int MaxHitPoints { get { return CON ().Value + CON ().Mod; } }


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

		public int MaxHunger {
			get { return (CON().Value + 1)*10; }
		}

		public int Hunger 
		{
			get { return hunger; }
			set 
			{
				hunger = Math.Max (0, Math.Min (value, MaxHunger));;
			}
		}

		#endregion

		public bool IsDead
		{
			get { return hitPoints == 0;  }

		}

		public Skill GetSkill (SkillType type)
		{
			if (Skills.ContainsKey (type)) return Skills [type];
			throw new CantParticipateInContestException (this);
		}

		public IGameActor Equip (EquipableObject obj)
		{
			return obj.OnEquip (this);
		}

		public int GetChallengeRate ()
		{
			return CA;
		}

		public SkillType GetSkillType ()
		{
			return SkillType.COMBAT;
		}

		public void ContestFinished (Challenger challenger, bool challengerWon)
		{
			throw new NotImplementedException ();
		}

		public bool CanParticipate (Challenger challenger)
		{
			return true;
		}

		public int CA
		{
			get 
			{
				return 10 + equipedArmor.Bonus + DEX ().Mod;	
			}

		}
	}
}

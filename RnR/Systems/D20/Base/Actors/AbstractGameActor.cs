using System;
using System.Collections.Generic;

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

		#endregion

		public AbstractGameActor ()
		{
			skills = new Dictionary<SkillType, Skill> ();
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

		public Attribute STR { get { return _STR; } }
		public Attribute CON { get { return _CON; } }
		public Attribute DEX { get { return _DEX; } }
		public Attribute INT { get { return _INT; } }
		public Attribute WIS { get { return _WIS; } }
		public Attribute CHA { get { return _CHA; } }

		public string Name { get { return name; } }
		public int Money { get { return money; } set { money = value; } }
		public int HitPoints {
			get { return hitPoints; }
			set {
				hitPoints = Math.Max (0, Math.Min (value, MaxHitPoints));
			}
		}
		public int MaxHitPoints { get { return maxHitPoints; } }

		#endregion

		public bool IsDead () { return hitPoints == 0; }

		public Skill GetSkill (SkillType type)
		{
			if (skills.ContainsKey (type)) return skills [type];
			else throw new CantParticipateInContestException(this);
		}
	}
}

using System.Collections.Generic;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.Dice;

namespace RnR.Systems.D20
{
	public class GameCharacterBuilder
	{
		Attribute _STR, _DEX, _CON, _INT, _WIS, _CHA;
		Dictionary<SkillType, Skill> skills;
		string name;

		public GameCharacterBuilder ()
		{
			skills = new Dictionary<SkillType, Skill> ();
		}

		public GameCharacterBuilder SetAttribute (Attributes attr)
		{
			DiceRoll attrRoll = Dice.Dice.Roll (4, 6);
			attrRoll.DiscardLower ();
			var a = new Attribute (attrRoll.Sum, attr);

			switch (attr) {
			case Attributes.CHA:
				_CHA = a;
				break;
			case Attributes.CON:
				_CON = a;
				break;
			case Attributes.DEX:
				_DEX = a;
				break;
			case Attributes.INT:
				_INT = a;
				break;
			case Attributes.STR:
				_STR = a;
				break;
			case Attributes.WIS:
				_WIS = a;
				break;
			}

			return this;
		}

		public GameCharacterBuilder SetSkill (SkillType type)
		{
			var val = Dice.Dice.Roll (1, 6).Sum;

			switch (type) {
			case SkillType.COMBAT:
				skills.Add (type, new Skill (type, "Combat", val, _STR));
				break;
			case SkillType.DETECT_MAGIC:
				skills.Add (type, new Skill (type, "Detect magic", val, _INT));
				break;
			case SkillType.DODGE_TRAP:
				skills.Add (type, new Skill (type, "Dodge traps", val, _DEX));
				break;
			case SkillType.PINLOCK:
				skills.Add (type, new Skill (type, "Pinlock", val, _WIS));
				break;
			}

			return this;
		}

		public GameCharacterBuilder SetName (string name)
		{
			this.name = name;

			return this;
		}

		public GameCharacter Build ()
		{
			var ga = new GameActor (_STR.Value,
									_DEX.Value,
									_CON.Value,
									_INT.Value,
								  	_WIS.Value,
									_CHA.Value);
			
			var gc = new GameCharacter (name,
										ga);

			foreach (var skill in skills) {
				ga.Skills.Add (skill.Key, skill.Value);
			}

			return gc;
		}
	}
}

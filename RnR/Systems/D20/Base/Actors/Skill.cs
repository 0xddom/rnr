namespace RnR.Systems.D20.Base.Actors
{
	public class Skill
	{
		private Attribute attribute;
		private SkillType type;
		private string name;
		private int baseValue;

		public Skill (SkillType type, string name, int baseValue, Attribute attribute)
		{
			this.attribute = attribute;
			this.type = type;
			this.name = name;
			this.baseValue = baseValue;
		}

		public int BaseValue { get { return baseValue; } set { this.baseValue = value; } }
		public string Name { get { return name; } }

		public int Value { get { return baseValue + attribute.Mod; } }
	}
}

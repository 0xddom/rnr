namespace RnR.Systems.D20.Base.Actors
{
	public class Skill
	{
		private Attribute attribute;
		private SkillType type;
		private string name;
		private int baseValue;

		public Skill ()
		{
		}

		public int BaseValue { get { return baseValue; } }
	}
}

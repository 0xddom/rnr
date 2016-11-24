using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public class Contest
	{
		private SkillType usedSkill;
		private Challenge challenge;
		private Challenger challenger;

		public Contest (SkillType usedSkill, Challenge challenge, Challenger challenger)
		{
			this.challenge = challenge;
			this.challenger = challenger;
			this.usedSkill = usedSkill;
		}
	}
}

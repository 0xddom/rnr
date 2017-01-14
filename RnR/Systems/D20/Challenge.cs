using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public interface Challenge
	{
		int GetChallengeRate ();
		SkillType GetSkillType ();
		void ContestFinished (Challenger challenger, bool challengerWon);
		bool CanParticipate (Challenger challenger);
	}
}

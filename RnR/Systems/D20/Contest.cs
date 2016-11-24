using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20
{
	public class Contest
	{
		private Challenge challenge;
		private Challenger challenger;

		public Contest (Challenge challenge, Challenger challenger)
		{
			this.challenge = challenge;
			this.challenger = challenger;
		}

		public void Resolve ()
		{
			try {
				if (challenge.CanParticipate (challenger)) {
					int result = Dice.Dice.Roll (1, 20).Sum + challenger.GetSkill (challenge.GetSkill ()).Value;
					challenge.ContestFinished (challenger, result > challenge.GetChallengeRate ());
				}
			} catch (CantParticipateInContestException) {
				// Ignore
			}
		}
}
}

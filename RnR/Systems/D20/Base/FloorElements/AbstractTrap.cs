using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractTrap : AbstractFloorElement, Stepable, Challenge
	{
		protected bool armed;
		private int challengeRate;
		private bool applied;
		private SkillType skill;
		private Actors.IGameActor victim;

		public AbstractTrap (SkillType skill, int challengeRate)
		{
			this.challengeRate = challengeRate;
			applied = false;
			this.skill = skill;
			Arm ();
		}

		public void Arm ()
		{
			armed = true;
		}

		public void Disarm ()
		{
			armed = false;
		}

		public string OnStep (Party target)
		{
			if (armed) {
				var contest = new Contest (this, target.Leader);
				contest.Resolve ();
				Disarm ();
				return resultMsg;
			}
			return null;
		}

		string resultMsg;

		public bool Armed { get { return armed; } }

		public string ContestFinished (Challenger challenger, bool challengerWon)
		{
			if (!challengerWon) {
				return ApplyEffect (challenger as GameCharacter);
			}
			return "You find a trap before it can harm you.";
		}

		public bool CanParticipate (Challenger challenger)
		{
			return challenger is GameCharacter;
		}

		public int GetChallengeRate () { return challengeRate; }
		public SkillType GetSkillType ()
		{
			return skill;
		}

		protected abstract string ApplyEffect (GameCharacter target);
	}
}

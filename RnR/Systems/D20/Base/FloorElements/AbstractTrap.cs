using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.FloorElements
{
	public abstract class AbstractTrap : AbstractFloorElement, OnStepListener, Challenge
	{
		protected bool armed;
		private int challengeRate;
		private bool applied;
		private SkillType skill;
		private AbstractGameActor victim;

		public AbstractTrap (SkillType skill, int challengeRate)
		{
			this.challengeRate = challengeRate;
			this.applied = false;
			this.skill = skill;
			Disarm ();
		}

		public void Arm ()
		{
			armed = true;
		}

		public void Disarm ()
		{
			armed = false;
		}

		public AbstractGameActor OnStep (AbstractGameActor target)
		{
			if (armed) {
				Contest contest = new Contest (this, target);
				contest.Resolve ();
				armed = false;
				if (applied) {
					return victim;
				}
			}
			return target;
		}

		public bool Armed { get { return armed; } }

		public void ContestFinished (Challenger challenger, bool challengerWon)
		{
			AbstractGameActor aga = (AbstractGameActor)challenger;
			if (!challengerWon) {
				victim = ApplyEffect (aga);
				applied = true;
			}
		}

		public bool CanParticipate (Challenger challenger)
		{
			return challenger is AbstractGameActor;
		}

		public int GetChallengeRate () { return challengeRate; }
		public SkillType GetSkill ()
		{
			return skill;
		}

		protected abstract AbstractGameActor ApplyEffect (AbstractGameActor target);
	}
}

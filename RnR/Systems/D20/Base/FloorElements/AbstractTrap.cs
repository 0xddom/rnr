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
		private IGameActor victim;

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

		public IGameActor OnStep (IGameActor target)
		{
			if (armed) {
				Contest contest = new Contest (this, target);
				contest.Resolve ();
				Disarm ();
				if (applied) {
					return victim;
				}
			}
			return target;
		}

		public bool Armed { get { return armed; } }

		public void ContestFinished (Challenger challenger, bool challengerWon)
		{
			IGameActor aga = (IGameActor)challenger;
			if (!challengerWon) {
				victim = ApplyEffect (aga);
				applied = true;
			}
		}

		public bool CanParticipate (Challenger challenger)
		{
			return challenger is IGameActor;
		}

		public int GetChallengeRate () { return challengeRate; }
		public SkillType GetSkillType ()
		{
			return skill;
		}

		protected abstract IGameActor ApplyEffect (IGameActor target);
	}
}

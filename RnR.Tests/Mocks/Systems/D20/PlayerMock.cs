using System;
using RnR.Systems.D20;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Tests.Mocks.Systems.D20
{
	public class PlayerMock : PlayerGameActor
	{
		public PlayerMock (int maxHitPoints) : base(10,10,10,10,10,10)
		{
			this.maxHitPoints = maxHitPoints;
			hitPoints = MaxHitPoints;
		}

		public PlayerMock () : base (0, 0, 0, 0, 0, 0) {}

		public void AddSkill (Skill skill)
		{
			skills.Add (skill.Type, skill);
		}
	}
}

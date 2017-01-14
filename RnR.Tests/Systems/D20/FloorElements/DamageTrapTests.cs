using NUnit.Framework;
using RnR.Systems.D20;
using RnR.Systems.D20.Base.Actors;
using RnR.Tests.Mocks.Systems.D20;

namespace RnR.Tests.Systems.D20.FloorElements
{
	[TestFixture ()]
	public class DamageTrapTests
	{
		[Test ()]
		public void TestSpikeTrap ()
		{
#if DEBUG
			System.Console.WriteLine ("DEBUG is set up");
			#endif
			//var player = new PlayerMock (10);
			//player.AddSkill (new Skill (SkillType.DODGE_TRAP, "", 0, new Attribute (0, Attributes.DEX)));
			var spikeTrap = new RnR.Systems.D20.FloorElements.SpikeTrap (1, 1, 100);

			//var returnedPlayer = spikeTrap.OnStep (player);
			//Assert.AreEqual (9, returnedPlayer.HitPoints);
		}
	}
}

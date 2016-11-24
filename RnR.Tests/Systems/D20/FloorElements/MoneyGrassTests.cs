using System;
using NUnit.Framework;
using RnR.Systems.D20;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.FloorElements;
using RnR.Tests.Mocks.Systems.D20.Enemies;

namespace RnR.Tests.Systems.D20.FloorElements
{
	[TestFixture()]
	public class MoneyGrassTests
	{
		MoneyGrass grass;

		[SetUp]
		public void SetUp ()
		{
			grass = new MoneyGrass (20);
		}

		[Test ()]
		public void GrassApplyToPlayerGameActor ()
		{
			var player = new PlayerGameActor ();
			player.Money = 200;

			var returnedPlayer = grass.OnStep (player);

			Assert.AreEqual (returnedPlayer.Money, 220);
		}

		[Test ()]
		public void GrassDontApplyToOtherActors ()
		{
			var other = new EnemyMock ();
			other.Money = 200;

			var returnedActor = grass.OnStep (other);

			Assert.AreEqual (returnedActor.Money, 200);
		}

		[Test ()]
		public void GrassCantBePickedTwice ()
		{
			var player = new PlayerGameActor ();
			player.Money = 200;

			var returnedPlayer = grass.OnStep (player);
			returnedPlayer = grass.OnStep (returnedPlayer);

			// If picked twice should be 240
			Assert.AreEqual (returnedPlayer.Money, 220); 

		}
	}
}

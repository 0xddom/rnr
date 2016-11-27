using NUnit.Framework;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.Objects;
using RnR.Tests.Mocks.Systems.D20;

namespace RnR.Tests.Systems.D20.Base.Objects
{
	[TestFixture()]
	public class EarringTests
	{
		class STRPlusOne : GameActorDecorator
		{
			public STRPlusOne (GameActor target)
				: base (target)
			{
			}

			public override Attribute STR ()
			{
				//get {
				int val = Target.STR ().Value;
				var a = new Attribute (val + 1, Attributes.STR);
				return a;
				//}
			}
		}

		class DEXPlusOne : GameActorDecorator
		{
			public DEXPlusOne (GameActor target)
				: base (target)
			{
			}

			public override Attribute DEX ()
			{
				//get {
				int val = Target.DEX ().Value;
				var a = new Attribute (val + 1, Attributes.STR);
				return a;
				//}
			}
		}

		class MockEarring : AbstractEarring
		{
			public MockEarring (GameActorDecorator d)
				: base ("","",0,0, d)
			{}
		}

		[Test()]
		public void TestEarringIsApplied ()
		{
			var player = new PlayerMock ();
			var dexEarring = new MockEarring (new DEXPlusOne (player));

			Assert.AreEqual (10, player.DEX().Value);
			var returnedPlayer = player.Equip(dexEarring);
			Assert.AreEqual (11, returnedPlayer.DEX ().Value);
		}

		[Test ()]
		public void TestEarringReplaces ()
		{
			var player = new PlayerMock ();
			var dexEarring = new MockEarring (new DEXPlusOne (player));
			var strEarring = new MockEarring (new STRPlusOne (player));

			var returnedPlayer = player.Equip (dexEarring);
			Assert.AreEqual (11, returnedPlayer.DEX ().Value);
			returnedPlayer = returnedPlayer.Equip (strEarring);
			Assert.AreEqual (11, returnedPlayer.STR ().Value);
			Assert.AreEqual (10, returnedPlayer.DEX ().Value);
		}
	}
}

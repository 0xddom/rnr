using NUnit.Framework;
using RnR.Systems.D20.Base.Actors;
using RnR.Tests.Mocks.Systems.D20;

namespace RnR.Tests.Systems.D20.Base.Actors
{
	[TestFixture ()]
	public class GameActorDecoratorTests
	{
		class STRPlusOne : GameActorDecorator
		{
			public STRPlusOne (GameActor target)
				: base (target)
			{
			}

			public override Attribute STR() {
				//get {
					int val = Target.STR().Value;
					var a= new Attribute (val + 1, Attributes.STR);
					return a;
				//}
			}
		}
	
		[Test ()]
		public void TestDecorationWithOneDecorator ()
		{
			var player = new PlayerMock ();
			var deco1 = new STRPlusOne (player);

			Assert.AreEqual (10, player.STR().Value);
			Assert.AreEqual (11, deco1.STR().Value);
		}

		[Test ()]
		public void TestDecorationWithTwoDecorators ()
		{
			var player = new PlayerMock ();
			var deco1 = new STRPlusOne (player);
			var deco2 = new STRPlusOne (deco1);

			Assert.AreEqual (10, player.STR().Value);
			Assert.AreEqual (deco1, deco2.Target);
			Assert.AreEqual (12, deco2.STR().Value);
		}

		[Test ()]
		public void TestDecorationRemove ()
		{
			var player = new PlayerMock ();
			var deco1 = new STRPlusOne (player);
			var deco2 = new STRPlusOne (deco1);
			var deco3 = new STRPlusOne (deco2);
			var deco4 = new STRPlusOne (deco3);

			Assert.AreEqual (14, deco4.STR ().Value);

			GameActorDecorator.Remove (deco4, deco2);
			Assert.AreEqual (13, deco4.STR ().Value);
		}

		[Test ()]
		public void TestDecoratorsAffectSkills ()
		{
			var player = new PlayerMock ();
			var deco = new STRPlusOne (player);
			player.AddSkill (new Skill (SkillType.PINLOCK, "Pinlock", 0, player.STR ()));

			Assert.AreEqual (10, player.GetSkill (SkillType.PINLOCK).Attribute.Value);
			Assert.AreEqual (11, deco.GetSkill (SkillType.PINLOCK).Attribute.Value);
		}
	}
}

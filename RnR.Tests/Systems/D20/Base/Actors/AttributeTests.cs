using NUnit.Framework;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Tests.Systems.D20.Base.Actors
{

	[TestFixture ()]
	public class AttributeTests
	{
		[Test ()]
		public void TestModWithEvenValue ()
		{
			Attribute attr = new Attribute (12, Attributes.STR);
			int expectedMod = 1;

			Assert.AreEqual (expectedMod, attr.Mod);
		}

		[Test ()]
		public void TestModWithOddValue ()
		{
			Attribute attr = new Attribute (13, Attributes.STR);
			int expectedMod = 1;

			Assert.AreEqual (expectedMod, attr.Mod);
		}
	}
}

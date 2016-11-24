using System;
using NUnit.Framework;
using RnR.Systems;

namespace RnR.Tests.Systems.Dice
{
	[TestFixture()]
	public class DiceTests
	{

		[Test ()]
		public void TestOneDiceOfOneSide ()
		{
			RnR.Systems.Dice.DiceRoll roll = RnR.Systems.Dice.Dice.Roll (1, 1);
			Assert.AreEqual (1, roll.Count);
			Assert.AreEqual (1, roll.Sum);
		}
	}
}

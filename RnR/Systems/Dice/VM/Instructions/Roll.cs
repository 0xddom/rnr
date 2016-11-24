using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM.Instructions
{
	public class Roll : AbstractInstruction
	{
		public override void Execute (Context context)
		{
			var sides = (IntegerType)context.Pop ();
			var nDices = (IntegerType)context.Pop ();

			context.Push (
				new DiceRollType (
					DiceOperations.Dice.roll (
						(int)nDices.GetValue (), 
						(int)sides.GetValue ())));
		}

		public override string ToString ()
		{
			return string.Format ("[Roll]");
		}
	}
}

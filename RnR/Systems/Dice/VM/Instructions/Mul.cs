using System;
using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM.Instructions
{
	public class Mul : AbstractInstruction
	{
		public override void Execute (Context context)
		{
			AddableType op1 = (AddableType)PopAndCast (context, typeof (AddableType));
			AddableType op2 = (AddableType)PopAndCast (context, typeof (AddableType));

			context.Push (new NumberType (op1.GetAddableValue () * op2.GetAddableValue ()));
		}

		public override string ToString ()
		{
			return string.Format ("[Mul]");
		}
	}
}

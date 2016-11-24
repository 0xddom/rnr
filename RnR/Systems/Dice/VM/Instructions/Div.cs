using System;
using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM.Instructions
{
	public class Div : AbstractInstruction
	{
		public override void Execute (Context context)
		{
			AddableType op1 = (AddableType)PopAndCast (context, typeof (AddableType));
			AddableType op2 = (AddableType)PopAndCast (context, typeof (AddableType));

			context.Push (new NumberType (op2.GetAddableValue () / op1.GetAddableValue ()));		}

		public override string ToString ()
		{
			return string.Format ("[Div]");
		}
	}
}

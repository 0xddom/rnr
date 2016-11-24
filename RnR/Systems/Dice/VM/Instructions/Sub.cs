using System;
using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM.Instructions
{
	public class Sub : AbstractInstruction
	{
		public override void Execute (Context context)
		{
			SubstraibleType op1 = (SubstraibleType)PopAndCast (context, typeof (SubstraibleType));
			SubstraibleType op2 = (SubstraibleType)PopAndCast (context, typeof (SubstraibleType));

			context.Push (new NumberType (op2.GetSubstraibleValue () - op1.GetSubstraibleValue ()));
		}

		public override string ToString ()
		{
			return string.Format ("[Sub]");
		}
	}
}

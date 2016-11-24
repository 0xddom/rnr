using System;
using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM.Instructions
{
	public abstract class AbstractInstruction : Instruction
	{
		public abstract void Execute (Context context);

		protected VMType PopAndCast (Context c, Type type)
		{
			VMType t = c.Pop ();
			if (!(t.GetType().Equals(type))) {
				throw new VMRuntimeException (t, type);
			}
			return t;
		}
	}
}

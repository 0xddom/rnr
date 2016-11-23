using System;
using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM.Instructions
{
	public class Push : AbstractInstruction
	{
		private int value;

		public Push (int value)
		{
			this.value = value;
		}

		public override void Execute (Context context)
		{
			context.Push (new IntegerType (value));
		}

		public override string ToString ()
		{
			return string.Format ("[Push] {0}", value);
		}
	}
}

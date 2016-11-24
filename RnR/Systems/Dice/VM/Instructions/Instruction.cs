using System;
using RnR.Systems.Dice.VM;

namespace RnR.Systems.Dice.VM.Instructions
{
	public interface Instruction
	{
		void Execute (Context context);
	}
}

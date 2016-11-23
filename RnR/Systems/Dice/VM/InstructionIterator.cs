using System;
using RnR.Systems.Dice.VM.Instructions;

namespace RnR.Systems.Dice.VM
{
	public interface InstructionIterator
	{
		Instruction NextInstruction ();
		bool HasMoreInstructions ();
	}
}

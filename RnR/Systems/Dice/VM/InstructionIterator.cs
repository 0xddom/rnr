using System;
namespace RnR.Systems.Dice.VM
{
	public interface InstructionIterator
	{
		Instruction NextInstruction ();
		bool HasMoreInstructions ();
	}
}

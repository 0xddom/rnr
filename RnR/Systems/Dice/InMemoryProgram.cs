using System;
using System.Collections.Generic;
using RnR.Systems.Dice.VM;
using RnR.Systems.Dice.VM.Instructions;

namespace RnR.Systems.Dice
{
	class InMemoryProgram : InstructionIterator
	{
		List<Instruction> program;
		int pc;

		public InMemoryProgram (List<Instruction> program)
		{
			this.program = program;
			pc = 0;
		}

		public bool HasMoreInstructions ()
		{
			return pc < program.Count;
		}

		public Instruction NextInstruction ()
		{
			return program [pc++];
		}
	}
}
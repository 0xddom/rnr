using System.Collections.Generic;
using RnR.Systems.Dice.VM;

namespace RnR.Systems.Dice.Interpreter
{
	class InMemoryProgram : InstructionIterator
	{
		List<Instruction> program;

		public InMemoryProgram (List<Instruction> program)
		{
			this.program = program;
		}
	}
}
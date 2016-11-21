using System;
namespace RnR
{
	public interface Instruction
	{
		void Execute (Context context);
	}
}

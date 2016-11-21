using System;
namespace RnR
{
	public class Mul : Instruction
	{
		public Mul ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Mul]");
		}
	}
}

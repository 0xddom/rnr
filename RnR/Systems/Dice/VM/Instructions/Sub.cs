using System;
namespace RnR
{
	public class Sub : Instruction
	{
		public Sub ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Sub]");
		}
	}
}

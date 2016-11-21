using System;
namespace RnR
{
	public class Add : Instruction
	{
		public Add ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Add]");
		}
	}
}

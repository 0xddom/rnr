using System;
namespace RnR
{
	public class Div : Instruction
	{
		public Div ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Div]");
		}
	}
}

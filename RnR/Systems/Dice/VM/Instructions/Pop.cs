using System;
namespace RnR
{
	public class Pop : Instruction
	{
		public Pop ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Pop]");
		}
	}
}

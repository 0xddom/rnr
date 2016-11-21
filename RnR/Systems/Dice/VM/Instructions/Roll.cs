using System;
namespace RnR
{
	public class Roll : Instruction
	{
		public Roll ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Roll]");
		}
	}
}

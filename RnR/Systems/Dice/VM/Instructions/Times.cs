using System;
namespace RnR
{
	public class Times : Instruction
	{
		public Times ()
		{
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Times]");
		}
	}
}

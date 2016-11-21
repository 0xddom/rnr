using System;
namespace RnR
{
	public class Push : Instruction
	{
		private int value;

		public Push (int value)
		{
			this.value = value;
		}

		public void Execute (Context context)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return string.Format ("[Push] {0}", value);
		}
	}
}

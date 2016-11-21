using System;
using System.Runtime.Serialization;

namespace RnR.Systems.Dice.Interpreter
{
	[Serializable]
	class CompilerException : Exception
	{
		Exception e;

		public CompilerException ()
		{
		}

		public CompilerException (string message) : base (message)
		{
		}

		public CompilerException (Exception e)
		{
			this.e = e;
		}

		public CompilerException (string message, Exception innerException) : base (message, innerException)
		{
		}

		protected CompilerException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}
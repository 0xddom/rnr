using System;
using System.Runtime.Serialization;

namespace RnR.Systems.Dice.Interpreter
{
	[Serializable]
	class SyntaxException : Exception
	{
		public SyntaxException()
		{
		}

		public SyntaxException(string message) : base(message)
		{
		}

		public SyntaxException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public SyntaxException(string error, int pos) : this(string.Format("Syntax error at position {0}: {1}", error, pos))
		{
		}

		protected SyntaxException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
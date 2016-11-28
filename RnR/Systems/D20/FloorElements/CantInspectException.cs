using System;
using System.Runtime.Serialization;

namespace RnR.Systems.D20.FloorElements
{
	[Serializable]
	class CantInspectException : Exception
	{
		public CantInspectException ()
		{
		}

		public CantInspectException (string message) : base (message)
		{
		}

		public CantInspectException (string message, Exception innerException) : base (message, innerException)
		{
		}

		protected CantInspectException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}
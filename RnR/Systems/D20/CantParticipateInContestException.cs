using System;
using System.Runtime.Serialization;

namespace RnR.Systems.D20
{
	[Serializable]
	class CantParticipateInContestException : Exception
	{
		public CantParticipateInContestException ()
		{
		}

		public CantParticipateInContestException (string message) : base (message)
		{
		}

		public CantParticipateInContestException (Challenger c) : base(string.Format("The challenger {0} cant participate!", c.GetType().Name))
		{
		}

		public CantParticipateInContestException (string message, Exception innerException) : base (message, innerException)
		{
		}

		protected CantParticipateInContestException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}
using System;
using System.Runtime.Serialization;
using RnR.Systems.Dice.VM.Types;

namespace RnR.Systems.Dice.VM
{
	[Serializable]
	class VMRuntimeException : Exception
	{
		VMType vmt;
		Type t;

		public VMRuntimeException ()
		{
		}

		public VMRuntimeException (string message) : base (message)
		{
		}

		public VMRuntimeException (string message, Exception innerException) : base (message, innerException)
		{
		}

		public VMRuntimeException (VMType vmt, Type t)
		{
			this.t = t;
			this.vmt = vmt;
		}

		protected VMRuntimeException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}
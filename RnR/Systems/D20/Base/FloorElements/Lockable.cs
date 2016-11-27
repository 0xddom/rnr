using System;
namespace RnR.Systems.D20.Base.FloorElements
{
	public interface Lockable : Challenge
	{
		bool IsLocked { get; }
		void Lock ();
		void UnLock ();
	}
}

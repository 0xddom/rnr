using System;

namespace Lain
{
	/// <summary>
	/// The behaviour of an Action (Command pattern)
	/// </summary>
	public interface IAction
	{
		bool Execute();
	}
}


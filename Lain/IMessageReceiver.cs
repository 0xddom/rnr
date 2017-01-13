using System;

namespace Lain
{
	/// <summary>
	/// The behaviour of a message receiver. (Chain of responsibility?)
	/// </summary>
	public interface IMessageReceiver
	{
		bool ReceiveMessage(Message message, object[] data);
		void AddReceiver(IMessageReceiver receiver);
	}
}


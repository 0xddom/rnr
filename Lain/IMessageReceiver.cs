using System;

namespace Lain
{
	public interface IMessageReceiver
	{
		bool ReceiveMessage(Message message, object[] data);
		void AddReceiver(IMessageReceiver receiver);
	}
}


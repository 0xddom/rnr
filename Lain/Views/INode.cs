using System;
using Microsoft.Xna.Framework;

namespace Lain.Views
{
	public interface INode : IMessageReceiver
	{
		void Update(GameTime delta);
		void Draw(GameTime delta);
	}
}


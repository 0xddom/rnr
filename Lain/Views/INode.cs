using System;
using Microsoft.Xna.Framework;

namespace Lain.Views
{
	/// <summary>
	/// Especifies the behavior of a node in the graphic components tree.
	/// </summary>
	public interface INode : IMessageReceiver
	{
		/// <summary>
		/// Called during the update step in the game loop.
		/// </summary>
		/// <param name="delta">Delta time.</param>
		void Update(GameTime delta);

		/// <summary>
		/// Called during the draw step in the game loop.
		/// </summary>
		/// <param name="delta">Delta time.</param>
		void Draw(GameTime delta);
	}
}


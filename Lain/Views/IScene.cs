using System;
using Microsoft.Xna.Framework;

namespace Lain.Views
{
	/// <summary>
	/// Especifies the behavior of the scene life cycle.
	/// </summary>
	public interface IScene : INode
	{
		/// <summary>
		/// Called when the scene is created.
		/// </summary>
		void OnCreate();

		/// <summary>
		/// Called when the scene is paused.
		/// </summary>
		void OnPause();

		/// <summary>
		/// Called when the scene is resumed.
		/// </summary>
		void OnResume();

		/// <summary>
		/// Called when the scene is destroyed and not needed anymore.
		/// </summary>
		void OnDestroy();
	}
}


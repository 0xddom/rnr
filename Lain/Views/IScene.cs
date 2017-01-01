using System;
using Microsoft.Xna.Framework;

namespace Lain.Views
{
	public interface IScene : INode
	{
		void OnCreate();
		void OnPause();
		void OnResume();
		void OnDestroy();
	}
}


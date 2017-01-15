using System;
namespace RnR.Scenes
{
	public interface CombatSceneState
	{
		void HandleInput ();
		void Update ();
	}
}

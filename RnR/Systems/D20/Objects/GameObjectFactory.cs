using System;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Objects
{
	public interface GameObjectFactory
	{
		GameObject CreateGameObject();
	}
}
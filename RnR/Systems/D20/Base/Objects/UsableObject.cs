
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{
    public interface UsableObject 
	{
        void OnUse(ref GameActor target);
    }
}
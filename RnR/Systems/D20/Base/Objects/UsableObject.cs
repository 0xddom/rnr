
using System;

namespace RnR.Systems.D20.Base.Objects;
{

    public interface UsableObject 
	{

        public void onUse(AbstractGameActor target);

    }
}
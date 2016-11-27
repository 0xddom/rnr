
using System;


namespace RnR.Systems.D20.Base.Objects;
{

    public interface EdibleObject 
	{


        public void onEat(AbstractGameActor target);

    }
}
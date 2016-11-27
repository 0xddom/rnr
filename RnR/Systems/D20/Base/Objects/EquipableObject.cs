
using System;


namespace RnR.Systems.D20.Base.Objects;
{

    public interface EquipableObject 
	{

        public void onEquip(AbstractGameActor target);

    }
}
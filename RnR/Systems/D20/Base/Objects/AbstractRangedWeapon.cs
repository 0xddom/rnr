
using System;

namespace RnR.Systems.D20.Base.Objects;
{

    public abstract class AbstractRangedWeapon : AbstractWeapon 
	{


        private int range;
        private AbstractAmmo ammo;


        public int getRange() 
		{
            return range;
        }


        public AbstractAmmo getAmmo() {
            return ammo;
        }

    }
}
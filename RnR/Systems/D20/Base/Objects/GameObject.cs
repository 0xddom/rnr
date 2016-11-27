
using System;


namespace RnR.Systems.D20.Base.Objects;
{

    public interface GameObject 
	{

        public bool isEquipable();

        public bool isUsable();

        public bool isEdible();

    }
}
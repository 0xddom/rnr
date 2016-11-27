
using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{

    public interface GameObject 
	{

        public bool isEquipable();

        public bool isUsable();

        public bool isEdible();

    }
}
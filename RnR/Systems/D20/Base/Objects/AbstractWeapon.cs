
using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{

    public abstract class AbstractWeapon : AbstractGameObject , EquipableObject 
	{

        private WeaponType type;
        private WeaponCategory category;
        private int criticRange;
        private int criticMultiplier;
        private DiceExpression damage;


        public WeaponType getType() 
		{
			return type;
        }

        public WeaponCategory getCategory() 
		{
			return category;
        }


        public int getCriticRange() 
		{
			return criticRange;
        }


        public int getCriticMultiplier()
		{
			return criticMultiplier;
        }


        public string getDamage() 
		{
			return damage;  //DiceExpresion
        }

    }
}
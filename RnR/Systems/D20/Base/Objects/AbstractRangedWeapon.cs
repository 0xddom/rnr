
using System;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractRangedWeapon : AbstractWeapon 
	{
		private readonly int range;
		private AbstractAmmo ammo;

        public int Range 
		{
			get {
				return range;
			}
        }

        public AbstractAmmo Ammo {
			get {
				return ammo;
			}
			set {
				ammo = value;
			}
        }

		public AbstractRangedWeapon (string name, string description, int weight, int price, WeaponType type, WeaponCategory category, int criticRange, int criticMultiplier, int dices, int damage, int range, AbstractAmmo ammo)
			: base (name, description, weight, price, type, category, criticRange, criticMultiplier, dices, damage)
		{
			this.range = range;
			this.ammo = ammo;
		}

    }
}
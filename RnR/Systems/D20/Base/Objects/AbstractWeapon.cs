
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractWeapon : AbstractGameObject , EquipableObject 
	{
        private WeaponType type;
        private WeaponCategory category;
        private int criticRange;
        private int criticMultiplier;
        private int damage;
		private int dices;

		public AbstractWeapon (string name, string description, int weight, int price, WeaponType type, WeaponCategory category, int criticRange, int criticMultiplier, int dices, int damage) 
			: base(name, description, weight, price)
		{
			this.type = type;
			this.category = category;
			this.criticRange = criticRange;
			this.criticMultiplier = criticMultiplier;
			this.dices = dices;
			this.damage = damage;
		}

        public WeaponType Type
		{
			get {
				return type;
			}
        }

        public WeaponCategory Category
		{
			get {
				return category;
			}
        }

        public int CriticRange
		{
			get {
				return criticRange;
			}
        }

        public int CriticMultiplier
		{
			get {
				return criticMultiplier;
			}
        }

		public GameActor OnEquip (GameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}
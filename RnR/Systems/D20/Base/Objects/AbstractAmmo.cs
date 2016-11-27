
using System;
using RnR.Systems.D20.Base.Actors;

namespace RnR.Systems.D20.Base.Objects
{

	public abstract class AbstractAmmo : AbstractGameObject, EquipableObject
	{
		private int rounds;

		public int Rounds {
			get {
				return rounds;
			}
		}

		AbstractAmmo (string name, string description, int weight, int price, int rounds) 
			: base (name, description, weight, price)
		{
			this.rounds = rounds;
		}

		public GameActor OnEquip (GameActor target)
		{
			target.EquipedAmmo = this;
			if (target.EquipedWeapon != null && target.EquipedWeapon is AbstractRangedWeapon) {
				((AbstractRangedWeapon)target.EquipedWeapon).Ammo = this;
			}
			return target;
		}

		public bool CanFire ()
		{
			return rounds != 0;
		}

		public void Fire ()
		{
			if (rounds == 0) {
				// TODO: Throw exception
			}
			rounds--;
		}
	}
}
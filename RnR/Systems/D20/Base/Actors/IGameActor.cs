using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Base.Actors
{
	public interface IGameActor : Challenge, Challenger 
	{
		Attribute STR ();
		Attribute DEX ();
		Attribute CON ();
		Attribute INT ();
		Attribute WIS ();
		Attribute CHA ();

		int HitPoints { get; set; }
		int MaxHitPoints { get; }
		int Hunger { get; set; }
		bool IsDead { get; }
		int Money { get; set; }
		int CA { get; }
		int MaxHunger { get; }

		AbstractWeapon EquipedWeapon { get; set; }
		AbstractArmor EquipedArmor { get; set; }
		AbstractRing EquipedRing { get; set; }
		AbstractEarring EquipedEarring { get; set; }
		AbstractNecklace EquipedNecklace { get; set; }



		IGameActor Equip (EquipableObject obj);
	}

}

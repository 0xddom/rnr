using System;
using System.Collections.Generic;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Base.Actors
{
	public interface GameActor : Challenger
	{
		Attribute STR { get; }
		Attribute DEX { get; }
		Attribute CON { get; }
		Attribute INT { get; }
		Attribute WIS { get; }
		Attribute CHA { get; }

		int HitPoints { get; set; }
		int MaxHitPoints { get; }

		int Money { get; set; }

		AbstractAmmo EquipedAmmo { get; set; }
		AbstractWeapon EquipedWeapon { get; set; }
		AbstractArmor EquipedArmor { get; set; }
		AbstractRing EquipedRing { get; set; }
		AbstractEarring EquipedEarring { get; set; }
		AbstractNecklace EquipedNecklace { get; set; }

		List<GameObject> Inventory { get; }

	}
}

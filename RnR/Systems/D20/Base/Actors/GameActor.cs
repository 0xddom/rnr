using System;
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
	}
}

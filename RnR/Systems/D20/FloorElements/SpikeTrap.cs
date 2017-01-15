using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;
using SadConsole;
using Microsoft.Xna.Framework;
using RnR.Consoles;

namespace RnR.Systems.D20.FloorElements
{
	public class SpikeTrap : AbstractDamageTrap
	{
		public SpikeTrap (int dices, int damage, int rate) 
			: base (SkillType.DODGE_TRAP, dices, damage, rate)
		{
		}

		protected override string ApplyEffect (GameCharacter target)
		{
			var dmg = CalculateDamage ();
			target.HitPoints -= dmg;
			return $"The spikes hurt you. You receive {dmg} ({dices}d{damage}) point of damage";
		}

		#region implemented abstract members of AbstractFloorElement

		public override CellAppearance Appearance (bool inFov)
		{
			if (inFov) {
				if (Armed)
					return new FloorInFovAppearance ();
				return new CellAppearance (Color.Red, Color.Transparent, 116);
			}
			if (Armed)
				return new FloorAppearance ();
			return new CellAppearance (Color.Red, Color.Transparent, 116);
		}

		#endregion
	}
}

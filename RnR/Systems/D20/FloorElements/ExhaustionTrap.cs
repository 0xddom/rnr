using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;
using SadConsole;
using Microsoft.Xna.Framework;
using RnR.Consoles;

namespace RnR.Systems.D20.FloorElements
{
	public class ExhaustionTrap : AbstractDamageTrap
	{
		public ExhaustionTrap (int dices, int damage, int rate) 
			: base (SkillType.DETECT_MAGIC, dices, damage, rate)
		{
		}

		protected override string ApplyEffect (GameCharacter target)
		{
			var dmg = CalculateDamage ();
			target.Hunger -= dmg;
			return $"The famine invades you and you gain {dmg} ({dices}d{damage}) point of hunger";
		}

		#region implemented abstract members of AbstractFloorElement

		public override CellAppearance Appearance (bool inFov)
		{
			if (inFov) {
				if (Armed)
					return new FloorInFovAppearance ();
				return new CellAppearance (Color.YellowGreen, Color.Transparent, 116);
			}
			if (Armed)
				return new FloorAppearance ();
			return new CellAppearance (Color.YellowGreen, Color.Transparent, 116);
		}

		#endregion
	}
}

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

		protected override IGameActor ApplyEffect (IGameActor target)
		{
			if (target is PlayerGameActor) {
				var player = (PlayerGameActor)target;
				player.Hunger -= CalculateDamage();
			}
			return target;
		}

		#region implemented abstract members of AbstractFloorElement

		public override SadConsole.CellAppearance Appearance (bool inFov)
		{
			if (inFov) {
				if (this.Armed)
					return new FloorInFovAppearance ();
				return new CellAppearance (Color.YellowGreen, Color.Transparent, 116);
			} else {
				if (this.Armed)
					return new FloorAppearance ();
				return new CellAppearance (Color.YellowGreen, Color.Transparent, 116);
			}
		}

		#endregion
	}
}

using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;
using RnR.Systems.D20.Effects;
using SadConsole;
using Microsoft.Xna.Framework;
using RnR.Consoles;

namespace RnR.Systems.D20.FloorElements
{
	public class StuntTrap : AbstractEffectTrap
	{
		public StuntTrap (int rate) 
			: base (SkillType.DETECT_MAGIC, new StuntEffect(null), rate)
		{
		}

		protected override string ApplyEffect (GameCharacter target)
		{
			target.AddEffect (Effect);
			return "You have been stunned by some magic";
		}

		#region implemented abstract members of AbstractFloorElement

		public override CellAppearance Appearance (bool inFov)
		{
			if (inFov) {
				if (Armed)
					return new FloorInFovAppearance ();
				return new CellAppearance (Color.LightBlue, Color.Transparent, 116);
			}
			if (Armed)
				return new FloorAppearance ();
			return new CellAppearance (Color.LightBlue, Color.Transparent, 116);
		}

		#endregion
	}
}

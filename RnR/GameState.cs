using System;
using System.Collections.Generic;
using RnR.Systems.D20;
using RnR.Systems.D20.Base.Actors;
using RnR.World;
using RnR.World.Generators;

namespace RnR
{
	public class GameState
	{
		#region Singleton
		/// <summary>
		/// The singleton instance.
		/// </summary>
		private static GameState instance = null;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static GameState Instance {
			get {
				if (instance == null) instance = new GameState ();
				return instance;
			}
		}
		#endregion

		public Dungeon Dungeon { get; private set; }
		public Party Party { get; private set; }

		readonly string [] names = {
			"Thomas", "Leonard", "Andre", "Dalton"
		};

		public GameState ()
		{
			Dungeon = new Dungeon (new SimpleFloorGenerationStrategy ());
			var cs = new List<GameCharacter> ();
			for (int i = 0; i < 4; i++) {
				var gc = new GameCharacterBuilder ()
					.SetAttribute (Attributes.STR)
					.SetAttribute (Attributes.DEX)
					.SetAttribute (Attributes.CON)
					.SetAttribute (Attributes.INT)
					.SetAttribute (Attributes.WIS)
					.SetAttribute (Attributes.CHA)
					.SetSkill (SkillType.COMBAT)
					.SetSkill (SkillType.DETECT_MAGIC)
					.SetSkill (SkillType.DODGE_TRAP)
					.SetSkill (SkillType.PINLOCK)
					.SetName (names [i])
					.Build ();
				cs.Add (gc);
			}
			Party = new Party (cs);
		}
	}
}


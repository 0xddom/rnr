using System;
using System.Collections.Generic;
using Lain;
using Microsoft.Xna.Framework.Input;
using RnR.Actions;
using RnR.Systems.D20;

namespace RnR.Scenes
{
	public class AskingForTargetState : CombatSceneState
	{
		CombatSceneContext context;
		int selectedTargetIdx;

		KeyboardState lastKbState;

		bool targetSelected;

		public AskingForTargetState (CombatSceneContext context)
		{
			this.context = context;
			selectedTargetIdx = 0;

			context.AvailableActions.Clear ();
			context.AvailableActions.Add ("(Up) Move up");
			context.AvailableActions.Add ("(Down) Move down");
			context.AvailableActions.Add ("(Enter) Select");

			targetSelected = false;
		}

		public void HandleInput ()
		{
			KeyboardState ks = Keyboard.GetState ();

			if (ks.IsKeyDown (Keys.Down) &&
				!lastKbState.IsKeyDown (Keys.Down)) {
				// Go down
				selectedTargetIdx++;
				if (selectedTargetIdx >= context.EnemyPartyStatusConsoles.Count)
					selectedTargetIdx = context.EnemyPartyStatusConsoles.Count - 1;
			} else if (ks.IsKeyDown (Keys.Up) &&
					   !lastKbState.IsKeyDown (Keys.Up)) {
				// Go up
				selectedTargetIdx--;
				if (selectedTargetIdx < 0)
					selectedTargetIdx = 0;
			} else targetSelected |= ks.IsKeyDown (Keys.Enter);

			lastKbState = ks;
		}

		public void Update ()
		{
			System.Console.WriteLine ("AskingForTargetState::Update");
			for (int i = 0; i < context.EnemyPartyStatusConsoles.Count; i++) {
				context.EnemyPartyStatusConsoles [i].IsSelected = i == selectedTargetIdx;
			}

			if (targetSelected) {
				for (int i = 0; i < context.EnemyPartyStatusConsoles.Count; i++) {
					context.EnemyPartyStatusConsoles [i].IsSelected = false;
				}

				IAction action = context.Actions [context.It.Current];
				if (action is AttackAction) {
					(action as AttackAction).Target = context.Combat.EnemyParty.Members [selectedTargetIdx];
				}

				if (context.It.MoveNext ()) {
					context.State = new AskingForActionState (context);
				} else {
					context.State = new DoTurnState (context);
				}
			}
		}
	}

}

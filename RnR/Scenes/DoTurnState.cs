using System;
using Lain;
using RnR.Actions;
using RnR.Systems.D20;

namespace RnR.Scenes
{
	public class DoTurnState : CombatSceneState
	{
		CombatSceneContext context;

		public DoTurnState (CombatSceneContext context)
		{
			this.context = context;
		}

		public void HandleInput ()
		{
			/* Do nothing */
		}

		public void Update ()
		{
			foreach (var enemy in context.Combat.EnemyParty) {
				var target = (enemy as EnemyCharacter).ChooseAttackTarget(context.Combat.PlayerParty.Members);
				IAction action = new AttackAction (context.Log);
				(action as AttackAction).Attacker = enemy;
				(action as AttackAction).Target = target;
				context.Actions.Add (enemy, action);
			}

			context.Combat.DoTurn (context.Actions);
			context.Actions.Clear ();
			context.It.Reset ();
			context.It.MoveNext ();
			context.State = new AskingForActionState (context);
		}
	}
}

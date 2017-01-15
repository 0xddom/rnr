using System;
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
			context.Combat.DoTurn (context.Actions);
			context.Actions.Clear ();
			context.It.Reset ();
			context.It.MoveNext ();
			context.State = new AskingForActionState (context);
		}
	}
}

using Lain;
using Microsoft.Xna.Framework.Input;
using RnR.Actions;

namespace RnR.Scenes
{
	public class AskingForActionState : CombatSceneState
	{
		bool actionSelected;
		IAction selectedAction;

		CombatSceneContext context;

		public AskingForActionState (CombatSceneContext context)
		{
			this.context = context;

			context.AvailableActions.Clear ();
			context.AvailableActions.Add ("(a) Attack");

			actionSelected = false;
		}

		public void HandleInput ()
		{
			KeyboardState s = Keyboard.GetState ();

			if (s.IsKeyDown (Keys.A)) {
				actionSelected = true;
				selectedAction = new AttackAction (context.Log);
			}
		}

		public void Update ()
		{
			var gc = context.It.Current;

			context.PlayerPartyStatusConsoles.ForEach ((statusConsole) => {
				statusConsole.IsSelected = statusConsole.Character == gc;
			});

			if (actionSelected) {
				context.Actions [gc] = selectedAction;
				if (selectedAction is AttackAction) {
					(selectedAction as AttackAction).Attacker = gc;
				}
				context.State = new AskingForTargetState (context);
			}
		}
	}
}

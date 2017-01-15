using System;
using System.Collections.Generic;
using Lain;
using Lain.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RnR.Actions;
using RnR.Consoles;
using RnR.Systems.D20;

namespace RnR.Scenes
{
	public class CombatScene : Scene
	{
		CombatSceneContext context;

		GameLogConsole logConsole;
		AvailableActionsConsole actionsConsole;

		public override void OnCreate ()
		{
			base.OnCreate ();

			context = new CombatSceneContext ();

			context.Combat = new Combat (GameState.Instance.Party, EnemyPartyFactory.Create());
			context.Actions = new Dictionary<GameCharacter, IAction> ();

			var gameLogConsoleWidth = (int)Math.Floor (Configuration.GridWidth * 1.0);
			var gameLogConsoleHeight = (int)Math.Floor (Configuration.GridHeight * 0.2);
			var statusConsoleWidth = (int)Math.Floor (Configuration.GridWidth * 0.5);
			var statusConsoleHeight = (int)Math.Floor ((Configuration.GridHeight - gameLogConsoleHeight - 3) / 4.0);

			context.Log = new List<string> ();
			context.PlayerPartyStatusConsoles = new List<AbstractCombatStatusConsole> ();
			context.EnemyPartyStatusConsoles = new List<AbstractCombatStatusConsole> ();

			logConsole = new GameLogConsole (context.Log, Math.Min (gameLogConsoleHeight - 2, 11), gameLogConsoleWidth, gameLogConsoleHeight);
			logConsole.Position = new Point (0, (int)Math.Floor (Configuration.GridHeight * 0.8) + 1);
			Add (logConsole);

			int i = 0;
			foreach (GameCharacter c in context.Combat.PlayerParty) {

				AbstractCombatStatusConsole status = new RightCombatStatusConsole (c, statusConsoleWidth, statusConsoleHeight);
				status.Position = new Point (statusConsoleWidth, i);
				i += statusConsoleHeight;

				context.PlayerPartyStatusConsoles.Add (status);
				Add (status);
			}

			i = 0;
			foreach (GameCharacter c in context.Combat.EnemyParty) {
				AbstractCombatStatusConsole status = new LeftCombatStatusConsole (c, statusConsoleWidth, statusConsoleHeight);
				status.Position = new Point (0, i);
				i += statusConsoleHeight;

				context.EnemyPartyStatusConsoles.Add (status);
				Add (status);
			}

			actionsConsole = new AvailableActionsConsole (gameLogConsoleWidth);
			context.AvailableActions = new List<string> ();
			actionsConsole.availableActions = context.AvailableActions;
			actionsConsole.Position = new Point (0, statusConsoleHeight * 4);
			Add (actionsConsole);

			context.It = context.Combat.PlayerParty.GetEnumerator ();
			context.It.MoveNext ();
			context.State = new AskingForActionState (context);

			SetBackground (new Color (new Vector3 (0x12, 0x13, 0x14)));
		}

		public override void OnDestroy ()
		{
			base.OnDestroy ();
		}

		public override void OnPause ()
		{
			base.OnPause ();
		}

		public override void OnResume ()
		{
			base.OnResume ();
		}

		public override void Update (GameTime delta)
		{
			KeyboardState state = Keyboard.GetState ();
			IAction action = new FalseAction ();

			if (state.IsKeyDown (Keys.Escape)) {
				(new ExitAction (0)).Execute();
			}

			base.Update (delta);

			context.State.HandleInput ();
			context.State.Update ();
		}
	}
}

using System;
namespace RnR.Systems.D20.Base.Actors
{
	public class GameActorDecorator : AbstractGameActor
	{
		protected AbstractGameActor target;

		public GameActorDecorator ()
		{
		}

		public AbstractGameActor Target { get { return target; } set { target = value; } }
	}
}

namespace RnR.Systems.D20.Base.Actors
{
	public abstract class AbstractEnemyActor : GameActor
	{
		public AbstractEnemyActor (int str, int dex, int con, int _int, int wis, int cha)
			: base (str, dex, con, _int, wis, cha)
		{
		}
	}
}


using System;
using RnR.Systems.D20.Base.Actors;
using RnR.Systems.D20.Base.FloorElements;

namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractTrapSetup : AbstractGameObject , UsableObject 
	{
        private AbstractTrap trap;

        public AbstractTrap Trap 
		{
			get {
				return trap;
			}
        }

        public AbstractTrapSetup(string name, string description, int weight, int price, AbstractTrap trap) 
			: base(name, description, weight, price)
		{
			this.trap = trap;
        }

		public void OnUse (ref GameActor target)
		{
			throw new NotImplementedException ();
		}
	}
}
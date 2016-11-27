
using System;


namespace RnR.Systems.D20.Base.Objects;
{

    public abstract class AbstractTrapSetup : AbstractGameObject , UsableObject 
	{



        private AbstractTrap trap;


        public AbstractTrap getTrap() 
		{

            return trap;
        }


        public AbstractTrapSetup(string name, string description, int weight, int price, AbstractTrap trap) 
		{
			this.trap = trap;
        }

    }
}
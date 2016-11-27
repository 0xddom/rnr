
using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{

    public abstract class AbstractAmmo : AbstractGameObject , EquipableObject 
	{

        
        private int rounds;


        public int getRounds()
		{
            return rounds;
        }


        public void AbstractAmmo(string name, string description, int weight, int price, int rounds) 
		{
			this.rounds = rounds;

        }

	}
}
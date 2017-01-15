using System;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Objects.Foods
{
	public class EnergyDrink : AbstractFood
	{
		public EnergyDrink () 
			: base("Bebida energetica",
				"No se como ha llegado esto aqui, pero no ha caducado, todavia",
				1, 30, 20)
		{
		}
	}
}


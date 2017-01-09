using System;
using RnR.Systems.D20.Base.Objects;

namespace RnR.Systems.D20.Objects.Foods
{
	public class EnergyDrink : AbstractFood
	{
		public EnergyDrink () 
			: base("Bebida energética",
				"No se como ha llegado esto aquí, pero no ha caducado, todavía",
				1, 30, 20)
		{
		}
	}
}


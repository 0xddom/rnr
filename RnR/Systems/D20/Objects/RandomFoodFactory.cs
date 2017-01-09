using System;
using RnR.Systems.D20.Base.Objects;
using System.Collections.Generic;
using System.Linq;

namespace RnR.Systems.D20.Objects
{
	public class RandomFoodFactory : GameObjectFactory
	{
		IEnumerable<Type> availableFoods;
		Random r;

		public RandomFoodFactory ()
		{
			availableFoods =
				from assembly in AppDomain.CurrentDomain.GetAssemblies ()
				from type in assembly.GetTypes ()
				where type.IsSubclassOf (typeof(AbstractFood))
				select type;

			r = new Random ();
		}

		#region GameObjectFactory implementation

		public RnR.Systems.D20.Base.Objects.GameObject CreateGameObject ()
		{
			var list = new List<Type> (availableFoods);

			// Instantiate a random subclass of AbstractFood
			return (GameObject) Activator.CreateInstance (list [r.Next (list.Count)]); 
		}

		#endregion
	}
}


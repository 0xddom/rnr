
using System;


namespace RnR.Systems.D20.Base.Objects
{

    public abstract class AbstractJunk : AbstractGameObject 
	{
		AbstractJunk (string name, string description, int weight, int price)
			: base (name, description, weight, price)
		{			
		}
    }
}
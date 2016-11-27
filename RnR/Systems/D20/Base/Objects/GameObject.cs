
using System;


namespace RnR.Systems.D20.Base.Objects
{
	public interface GameObject
	{
		bool IsEquipable { get; }
		bool IsUsable { get; }
		bool IsEdible { get; }

		string Name {
			get;
		}
		string Description {
			get;
		}
		int Weight {
			get;
		}
		int Price {
			get;
		}
	}
}
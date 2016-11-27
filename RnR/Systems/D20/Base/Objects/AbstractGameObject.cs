using System;


namespace RnR.Systems.D20.BasePackage.GameObject
{
	public class AbstractGameObject
	{
		private string name;
		private string description;
		private int weight;
		private int price;

		public AbstractGameObject(string name, string description, int weight, int price)
		{
			this.name = name;
			this.description = description;
			this.weight = weight;
			this.price = price;

		}
		public string GetName()
		{
			return name;
		}
		public string GetDescription()
		{
			return description;
		}
		public int GetWeight()
		{
			return weight;
		}
		public int GetPrice()
		{
			return price;
		}

	}

}

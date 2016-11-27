using System;


namespace RnR.Systems.D20.Base.Objects
{
	public class AbstractGameObject : GameObject
	{
		private string name;
		private string description;
		private int weight;
		private int price;

		public bool IsEquipable {
			get {
				return false;
			}
		}

		public bool IsUsable {
			get {
				return false;
			}
		}

		public bool IsEdible {
			get {
				return false;
			}
		}

		public AbstractGameObject(string name, string description, int weight, int price)
		{
			this.name = name;
			this.description = description;
			this.weight = weight;
			this.price = price;

		}
		public string Name
		{
			get {
				return name;
			}
		}
		public string Description
		{
			get {
				return description;
			}
		}
		public int Weight
		{
			get {
				return weight;
			}
		}
		public int Price
		{
			get {
				return price;
			}
		}

	}

}

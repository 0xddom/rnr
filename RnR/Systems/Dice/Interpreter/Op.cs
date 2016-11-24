using System;
namespace RnR.Systems.Dice.Interpreter
{
	public class Op
	{
		private string name;
		private int priority;
		private Associativity assoc;

		public Op(string name, int priority, Associativity assoc)
		{
			this.name = name;
			this.priority = priority;
			this.assoc = assoc;
		}

		public string Name { get { return name; } }
		public int Priority { get { return priority; } }
		public Associativity Assoc { get { return assoc; } }
	}
}

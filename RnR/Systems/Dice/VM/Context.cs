using System;
using RnR.Utils;

namespace RnR.Systems.Dice.VM
{
	public class Context : Stackable<Type>
	{
		private Stack<Type> stack;
		#region Registers
		private int
			ip,
			sp,
			bp,
			flags,
			r0,
			r1,
			r2,
			r3,
			r4,
			r5,
			r6,
			r7,
			r8,
			r9,
			r10,
			r11
		;
		#endregion

		public Context ()
		{
			stack = new Stack<Type> ();

		}

		public void Push (Type type)
		{
			stack.Push (type);
			sp++;
		}

		public Type Pop ()
		{
			sp--;
			return stack.Pop ();
		}

		public Type Peek ()
		{
			return stack.Peek ();
		}

		public int IP { get { return ip; } set { ip = value; } }
		public int SP { get { return sp; } set { sp = value; } }
		public int BP { get { return bp; } set { bp = value; } }
		public int FLAGS { get { return flags; } set { flags = value; } }
		public int R0 { get { return r0; } set { r0 = value; } }
		public int R1 { get { return r1; } set { r1 = value; } }
		public int R2 { get { return r2; } set { r2 = value; } }
		public int R3 { get { return r3; } set { r3 = value; } }
		public int R4 { get { return r4; } set { r4 = value; } }
		public int R5 { get { return r5; } set { r5 = value; } }
		public int R6 { get { return r6; } set { r6 = value; } }
		public int R7 { get { return r7; } set { r7 = value; } }
		public int R8 { get { return r8; } set { r8 = value; } }
		public int R9 { get { return r9; } set { r9 = value; } }
		public int R10 { get { return r10; } set { r10 = value; } }
		public int R11 { get { return r11; } set { r11 = value; } }

	}
}

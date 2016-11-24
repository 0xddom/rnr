using System;
using System.Collections.Generic;
using RnR.Systems.Dice.VM;
using RnR.Systems.Dice.VM.Instructions;
using RnR.Utils;

namespace RnR.Systems.Dice.Interpreter
{
	public class Compiler
	{
		public static InstructionIterator compile (string expr)
		{
			//throw new NotImplementedException ();
			var opStack = new Stack<Op> ();

			List<string> rpnExpr = new List<string> ();
			Tokenizer t = new Tokenizer (expr);

			try {
				while (t.HasMoreLexemes ()) {
					Lexeme l = t.NextLexeme ();
					if (l.Token.Length == 1 && IsOp (l.Token [0])) {
						Op op = GetOp (l.Token);
						while (HasMoreTokensToPush (opStack, op)) {
							rpnExpr.Add (opStack.Pop ().Name);
						}
						opStack.Push (op);
					} else if (l.Type == TokenType.LPARAM) {
						Op op = GetOp (l.Token);
						opStack.Push (op);
					} else if (l.Type == TokenType.RPARAM) {
						while (!opStack.Empty () && !(l.Type == TokenType.LPARAM)) {
							rpnExpr.Add (opStack.Pop ().Name);
						}
					} else {
						rpnExpr.Add (l.Token);
					}
				}

				while (!opStack.Empty ()) {
					if (IsParam (opStack.Peek ().Name))
						throw new Exception ("Mismatched parenthesis");
					rpnExpr.Add (opStack.Pop ().Name);
				}
			} catch (Exception e) {
				throw new CompilerException (e);
			}

			List<Instruction> program = BuildInstructions (rpnExpr);
			program.Add (new Halt ());
			return new InMemoryProgram (program);
		}

		private static Dictionary<string, Op> ops;

		#region Initialization
		static Compiler ()
		{
			ops = new Dictionary<string, Op> ();
			O (Tokens.DICE, 3, Associativity.LEFT);
			O (Tokens.ADD, 1, Associativity.LEFT);
			O (Tokens.SUB, 1, Associativity.LEFT);
			O (Tokens.MUL, 2, Associativity.LEFT);
			O (Tokens.DIV, 2, Associativity.LEFT);
			O (Tokens.LPARAM, -1, Associativity.NON_ASSOC);
			O (Tokens.RPARAM, -1, Associativity.NON_ASSOC);
			//O (Tokens.LOW, 2, Associativity.LEFT);
			//O (Tokens.HIGH, 2, Associativity.LEFT);
			//O (Tokens.TIMES, 2, Associativity.LEFT);
		}
		#endregion

		#region Helper methods
		private static void O (char name, int priority, Associativity assoc)
		{
			if (ops != null)
				ops.Add (CharToStr (name), new Op (CharToStr (name), priority, assoc));
		}

		static List<Instruction> BuildInstructions (List<string> rpnExpr)
		{
			return rpnExpr.ConvertAll(BuildInstruction);
		}

		static Instruction BuildInstruction (string input)
		{
			switch (input) {
				case "+": return new Add ();
				case "-": return new Sub ();
				case "*": return new Mul ();
				case "/": return new Div ();
				case "d": return new Roll ();
				default: return new Push (int.Parse (input));
			}
		}

		private static string CharToStr (char c) { return new string (new char [] { c }); }

		private static bool IsParam (string tok)
		{
			return tok.Equals (CharToStr (Tokens.LPARAM)) || tok.Equals (CharToStr (Tokens.RPARAM));
		}

		private static Op GetOp (string token)
		{
			return ops [token];
		}

		private static bool IsDigit (char c)
		{
			return char.IsDigit (c);
		}

		static bool HasMoreTokensToPush (Stack<Op> opStack, Op op)
		{
			return !opStack.Empty () &&
						   IsOp (opStack.Peek ().Name [0]) &&
						   ((op.Assoc == Associativity.LEFT && op.Priority <= opStack.Peek ().Priority) ||
							(op.Assoc == Associativity.RIGHT && op.Priority < opStack.Peek ().Priority));
		}

		private static bool IsOp (char c)
		{
			return ops.ContainsKey (CharToStr (c)) && ops [CharToStr (c)].Assoc != Associativity.NON_ASSOC;
		}
		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RnR.Systems.Dice.Interpreter
{
	public class Tokenizer : LexemeIterator
	{
		private char[] expr;
		private int pos;
		private List<Lexeme> queuedLexemes;
		private TokenType lastType;
		private TokenType nextType;
		private char lastToken;

		public Tokenizer(string expr)
		{
			this.expr = expr.ToCharArray();
			pos = 0;
			queuedLexemes = new List<Lexeme>();
			lastToken = '\0';
			lastType = nextType = TokenType.UNKNOWN;
		}

		public bool HasMoreLexemes()
		{
			return pos < expr.Length;
		}

		/// <summary>
		/// This method works but I'm not sure how. Better not touch it. Just in case.
		/// Some meme magic going on here.
		/// </summary>
		/// <returns>The next lexeme found in the input</returns>
		public Lexeme NextLexeme()
		{
			if (queuedLexemes.Count > 0)
			{
				Lexeme l = queuedLexemes[0];
				queuedLexemes.Remove(l);
				return l;
			}

			StringBuilder token = new StringBuilder();
			bool endOfToken = false;
			TokenType type = TokenType.UNKNOWN;

			while (!endOfToken && HasMoreLexemes())
			{
				lastToken = (pos != 0) ? expr[pos - 1] : '\0';
				while (expr[pos] == ' ' && HasMoreLexemes()) pos++;

				switch (expr[pos])
				{
					case Tokens.DICE:
					case Tokens.ADD:
					case Tokens.MUL:
					case Tokens.DIV:
					case Tokens.TIMES:
						if (type != TokenType.NUMBER)
						{
							type = TokenType.OPERATOR;
							token.Append(expr[pos++]);
						}
						endOfToken = true;
						break;
					case Tokens.SUB:
						if (type == TokenType.NUMBER) endOfToken = true;
						else
						{
							if (lastType == TokenType.NUMBER || lastType == TokenType.MODIFIER)
							{
								type = TokenType.OPERATOR;
								token.Append(expr[pos++]);
								endOfToken = true;
							}
							else {
								type = TokenType.NUMBER;
								token.Append(expr[pos++]);
							}
						}
						break;
					case Tokens.HIGH:
					case Tokens.LOW:
						if (lastToken == Tokens.SUB)
						{
						}
						else throw new SyntaxException("L or H operator expects to be after '-'", pos);
						break;
					case Tokens.LPARAM:
						token.Append(expr[pos++]);
						type = TokenType.LPARAM;
						endOfToken = true;
						break;
					case Tokens.RPARAM:
						if (nextType != TokenType.RPARAM) nextType = TokenType.RPARAM;
						else {
							type = nextType;
							token.Append(expr[pos++]);
						}
						endOfToken = true;
						break;
					case ' ':
						endOfToken = true;
						pos++;
						break;
					default:
						if (IsDigit(expr[pos]))
						{
							token.Append(expr[pos]);
							type = TokenType.NUMBER;
						}
						else throw new SyntaxException("Unrecognized element", pos);
						pos++;
						break;
				}
			}
			lastType = type;
			return new Lexeme(type, token.ToString());
		}

		private bool IsDigit(char c)
		{
			return char.IsDigit(c);
		}
	}
}

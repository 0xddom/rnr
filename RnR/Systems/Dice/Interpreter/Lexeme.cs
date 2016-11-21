using System;
namespace RnR.Systems.Dice.Interpreter
{
	public class Lexeme
	{
		private TokenType type;
		private string token;

		public Lexeme(TokenType type, string token)
		{
			this.type = type;
			this.token = token;
		}

		public TokenType Type { get { return type; } }
		public string Token { get { return token; } }
	}
}

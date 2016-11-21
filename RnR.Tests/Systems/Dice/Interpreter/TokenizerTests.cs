using System.Collections.Generic;
using NUnit.Framework;
using RnR.Systems.Dice.Interpreter;

namespace RnR.Tests
{
	[TestFixture()]
	public class TokenizerTests
	{
		private Lexeme[] Run(string expr)
		{
			var lexemes = new List<Lexeme>();
			var tokenizer = new Tokenizer(expr);
			while (tokenizer.HasMoreLexemes()) lexemes.Add(tokenizer.NextLexeme());
			return lexemes.ToArray();
		}

		private void AssertsLexemesAreEqual(Lexeme expected, Lexeme actual)
		{
			Assert.AreEqual(expected.Token, actual.Token);
			Assert.AreEqual(expected.Type, actual.Type);
		}

		private void AssertLexemeCollectionsAreEqual(Lexeme[] expected, Lexeme[] actual)
		{

			Assert.AreEqual(expected.Length, actual.Length);
			for (int i = 0; i < expected.Length; i++)
			{
				AssertsLexemesAreEqual(expected[i], actual[i]);
			}
		}

		private Lexeme L(TokenType type, string token)
		{
			return new Lexeme(type, token);
		}

		private void RunCommonTest(string input, Lexeme[] expected)
		{
			AssertLexemeCollectionsAreEqual(expected, Run(input));
		}

		[Test()]
		public void AddTokenTest()
		{
			RunCommonTest("+", new Lexeme[] {
				L(TokenType.OPERATOR, "+")
			});
		}

		[Test()]
		public void SimpleAdditionTest()
		{
			RunCommonTest("1+1", new Lexeme[] {
				L(TokenType.NUMBER, "1"),
				L(TokenType.OPERATOR, "+"),
				L(TokenType.NUMBER, "1")
			});
		}

		[Test()]
		public void FormulaWithNegativeNumber()
		{
			RunCommonTest("2+(-3*5)", new Lexeme[] {
				L(TokenType.NUMBER, "2"),
				L(TokenType.OPERATOR, "+"),
				L(TokenType.LPARAM, "("),
				L(TokenType.NUMBER, "-3"),
				L(TokenType.OPERATOR, "*"),
				L(TokenType.NUMBER, "5"),
				L(TokenType.RPARAM, ")")
			});
		}
	}
}

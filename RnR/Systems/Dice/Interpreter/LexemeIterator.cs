using System;
namespace RnR.Systems.Dice.Interpreter
{
	public interface LexemeIterator
	{
		Lexeme NextLexeme();
		bool HasMoreLexemes();
	}
}

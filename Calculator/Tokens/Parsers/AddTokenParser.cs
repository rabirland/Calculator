using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Calculator.Nodes;
using AdvancedCalculator.Nodes;
using AdvancedCalculator.Tokens;

namespace Calculator.Tokens
{
	public class AddToken : Token
	{
		public AddToken(string representative)
		{

		}

		public override Node GetNode()
		{
			return new AddNode();
		}

		public override string ToString()
		{
			return "+";
		}
	}

	public class AddTokenParser : ITokenParser
	{
		char AddMark = '+';

		public Token TryParse(string stream)
		{
			if (string.IsNullOrEmpty(stream)) return null;

			if (stream[0] == AddMark) return new AddToken("+");
			else return null;
		}

		public int TryParse(string stream, TokenParser parser, out Token token) => throw new NotImplementedException();
	}
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class AddOperatorToken : Token
	{
		public AddOperatorToken()
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

	public class AddOperatorTokenParser : ITokenParser
	{
		char AddMark = '+';

		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (string.IsNullOrEmpty(stream)) return 0;

			if (stream[0] == AddMark)
			{
				token = new AddOperatorToken();
				return 1;
			}
			else return 0;
		}
	}
}

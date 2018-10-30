using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class MultiplyOperatorToken : Token
	{
		public override Node GetNode()
		{
			return new MultiplyNode();
		}

		public override string ToString()
		{
			return Constants.MultiplyOperator.ToString();
		}
	}

	public class MultiplyOperatorTokenParser : ITokenParser
	{
		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (string.IsNullOrEmpty(stream)) return 0;

			if (stream[0] == Constants.MultiplyOperator)
			{
				token = new MultiplyOperatorToken();
				return 1;
			}
			else return 0;
		}
	}
}

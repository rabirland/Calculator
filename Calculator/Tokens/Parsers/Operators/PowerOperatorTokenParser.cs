using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class PowerOperatorToken : Token
	{
		public override Node GetNode()
		{
			return new PowerOperatorNode();
		}

		public override string ToString()
		{
			return Constants.PowerOperator.ToString();
		}
	}

	public class PowerOperatorTokenParser : ITokenParser
	{
		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (string.IsNullOrEmpty(stream)) return 0;

			if (stream[0] == Constants.PowerOperator)
			{
				token = new PowerOperatorToken();
				return 1;
			}
			else return 0;
		}
	}
}

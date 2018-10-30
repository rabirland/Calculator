using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class SubtractOperatorToken : Token
	{
		public override Node GetNode()
		{
			return new SubtractNode();
		}

		public override string ToString()
		{
			return Constants.SubtractOperator.ToString();
		}
	}

	public class SubtractOperatorTokenParser : ITokenParser
	{
		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (string.IsNullOrEmpty(stream)) return 0;

			if (stream[0] == Constants.SubtractOperator)
			{
				token = new SubtractOperatorToken();
				return 1;
			}
			else return 0;
		}
	}
}

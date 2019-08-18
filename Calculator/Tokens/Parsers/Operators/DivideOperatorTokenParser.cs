using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class DivideOperatorToken : Token
	{
		public override Node GetNode()
		{
			return new DivideNode();
		}

		public override string ToString()
		{
			return Constants.MultiplyOperator.ToString();
		}
	}

	public class DivideOperatorTokenParser : ITokenParser
	{
		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (string.IsNullOrEmpty(stream)) return 0;

			if (stream[0] == Constants.DivideOperator)
			{
				token = new DivideOperatorToken();
				return 1;
			}
			else return 0;
		}
	}
}

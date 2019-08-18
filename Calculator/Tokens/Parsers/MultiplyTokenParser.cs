using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class MultiplyToken : Token
	{
		public MultiplyToken(string representative)
		{

		}

		public override Node GetNode()
		{
			return new MultiplyNode();
		}

		public override string ToString()
		{
			return "*";
		}
	}

	public class MultiplyTokenParser : ITokenParser
	{
		char AddMark = '*';

		public Token TryParse(string stream)
		{
			if (string.IsNullOrEmpty(stream)) return null;

			if (stream[0] == AddMark) return new MultiplyToken("*");
			else return null;
		}

		public int TryParse(string stream, TokenParser parser, out Token token) => throw new NotImplementedException();
	}
}

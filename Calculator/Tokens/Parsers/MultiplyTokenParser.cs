using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Calculator.Nodes;

namespace Calculator.Tokens
{
	public class MultiplyToken : Token
	{
		public MultiplyToken(string representative) : base(representative)
		{

		}

		public override Node GetNode()
		{
			return new MultiplyNode(null, null);
		}

		public override string ToString()
		{
			return this.Representative;
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
	}
}

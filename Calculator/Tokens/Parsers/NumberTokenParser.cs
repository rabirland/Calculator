using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Calculator.Nodes;

namespace Calculator.Tokens
{
	public class NumberToken : Token
	{
		public NumberToken(string representative) : base(representative)
		{

		}

		public override Node GetNode()
		{
			return new NumberNode(decimal.Parse(this.Representative));
		}

		public override string ToString()
		{
			return this.Representative;
		}
	}

	public class NumberTokenParser : ITokenParser
	{
		private static readonly char[] Numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		public Token TryParse(string stream)
		{
			if (!Numbers.Contains(stream[0])) return null;

			string value = "";

			int i;
			for (i = 0; i < stream.Length && Numbers.Contains(stream[i]); i++)
				value += stream[i];

			return new NumberToken(value);
		}
	}
}

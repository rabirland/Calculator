using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Calculator.Nodes;

namespace Calculator.Tokens
{
	public class AddToken : Token
	{
		public AddToken(string representative) : base(representative)
		{

		}

		public override Node GetNode()
		{
			return new AddNode(null, null);
		}

		public override string ToString()
		{
			return this.Representative;
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
	}
}

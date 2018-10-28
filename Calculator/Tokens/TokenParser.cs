using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Tokens
{
	public class TokenParser
	{
		public List<ITokenParser> TokenParsers;

		public TokenParser()
		{
			this.TokenParsers = new List<ITokenParser>();

			this.TokenParsers.Add(new NumberTokenParser());
			this.TokenParsers.Add(new AddTokenParser());
			this.TokenParsers.Add(new MultiplyTokenParser());
		}

		public Token[] Parse(string stream)
		{
			List<Token> ret = new List<Token>();

			while (stream.Length > 0)
			{
				foreach (ITokenParser parser in this.TokenParsers)
				{
					Token token = parser.TryParse(stream);
					if (token != null)
					{
						ret.Add(token);
						stream = stream.Remove(0, token.Representative.Length);
						continue;
					}
				}
			}

			return ret.ToArray();
		}
	}
}

using System.Collections.Generic;

namespace AdvancedCalculator.Tokens
{
	public class TokenParser
	{
		public List<ITokenParser> TokenParsers;

		public TokenParser()
		{
			this.TokenParsers = new List<ITokenParser>();

			//Basic
			this.TokenParsers.Add(new NumberTokenParser());
			this.TokenParsers.Add(new BracketTokenParser());

			//Operators
			this.TokenParsers.Add(new AddOperatorTokenParser());
			this.TokenParsers.Add(new SubtractOperatorTokenParser());

			this.TokenParsers.Add(new MultiplyOperatorTokenParser());
			this.TokenParsers.Add(new DivideOperatorTokenParser());

			this.TokenParsers.Add(new PowerOperatorTokenParser());

			//Functions
			this.TokenParsers.Add(new PowerFunctionTokenParser());
			this.TokenParsers.Add(new SqrtFunctionTokenParser());
			this.TokenParsers.Add(new SinFunctionTokenParser());
			this.TokenParsers.Add(new CosFunctionTokenParser());
			this.TokenParsers.Add(new TanFunctionTokenParser());
		}

		public Token[] Parse(string stream)
		{
			List<Token> ret = new List<Token>();

			while (stream.Length > 0)
			{
				foreach (ITokenParser parser in this.TokenParsers)
				{
					int parsed = parser.TryParse(stream, this, out Token token);
					if (parsed > 0)
					{
						ret.Add(token);
						stream = stream.Remove(0, parsed);
						continue;
					}

					if (stream.Length == 0) break;
				}
			}

			return ret.ToArray();
		}
	}
}

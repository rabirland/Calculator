using System;

namespace AdvancedCalculator.Tokens
{
    public abstract class OneArgumentFunctionTokenParserBase : ITokenParser
    {
		private readonly string _functionName;
		Func<Token[], Token> _factory;

		public OneArgumentFunctionTokenParserBase(string functionName, Func<Token[], Token> factory)
        {
			this._functionName = functionName;
			this._factory = factory;
        }

		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (stream.Length < this._functionName.Length + 1)
            {
				return 0;
			}

			if (stream.StartsWith($"{this._functionName}(", StringComparison.InvariantCultureIgnoreCase))
			{
				int closeBracketIndex = ParserHelper.FindNextTopLevelCloseBracket(stream, this._functionName.Length + 1);
				if (closeBracketIndex < 0)
                {
					return 0;
				}

				int parameterListStartIndex = this._functionName.Length + 1;
				string paramList = stream[parameterListStartIndex..closeBracketIndex];
				string[] parms = ParserHelper.SplitParams(paramList);
				if (parms.Length != 1)
                {
					return 0;
				}

				Token[] param1 = parser.Parse(parms[0]);

				token = this._factory(param1);
				return closeBracketIndex + 1; //+1 to include the close bracket too
			}

			return 0;
		}
	}
}

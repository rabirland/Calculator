using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class PowerFunctionToken : Token
	{
		Token[] baseParam;
		Token[] exponentParam;

		public PowerFunctionToken(Token[] baseParam, Token[] exponentParam)
		{
			if (baseParam == null || baseParam.Length == 0) throw new Exception("Empty argument");
			if (exponentParam == null || exponentParam.Length == 0) throw new Exception("Empty argument");

			this.baseParam = baseParam;
			this.exponentParam = exponentParam;
		}

		public override Node GetNode()
		{
			PowerFunctionNode ret = new PowerFunctionNode();
			ret[0] = NodeBuilder.BuildTree(this.baseParam);
			ret[1] = NodeBuilder.BuildTree(this.exponentParam);
			return ret;
		}

		public override string ToString()
		{
			return Constants.PowerOperator.ToString();
		}
	}

	public class PowerFunctionTokenParser : ITokenParser
	{
		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (stream.Length < 5) return 0;

			if (stream.StartsWith("pow(", StringComparison.InvariantCultureIgnoreCase))
			{
				int closeBracket = ParserHelper.FindNextTopLevelCloseBracket(stream, 4);
				if (closeBracket < 0) return 0;

				string paramList = stream.Substring(4, closeBracket - 4);
				string[] parms = ParserHelper.SplitParams(paramList);
				if (parms.Length != 2) return 0;

				Token[] baseParam;
				Token[] exponentParam;

				baseParam = parser.Parse(parms[0]);
				exponentParam = parser.Parse(parms[1]);

				token = new PowerFunctionToken(baseParam, exponentParam);
				return closeBracket + 1; //+1 to include the close bracket too
			}

			return 0;
		}
	}
}

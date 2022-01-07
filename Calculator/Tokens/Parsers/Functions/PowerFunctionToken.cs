using System;
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

	public class PowerFunctionTokenParser : TwoArgumentFunctionTokenParserBase<PowerFunctionToken>
	{
		public PowerFunctionTokenParser()
			: base("pow", (param1, param2) => new PowerFunctionToken(param1, param2))
        {
        }
	}
}

using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class TanFunctionToken : OneArgumentFunctionTokenBase<TanFunctionNode>
	{
		public TanFunctionToken(Token[] param)
			:base(param)
		{
		}

		public override string ToString()
		{
			return "Tan";
		}
	}

	public class TanFunctionTokenParser : OneArgumentFunctionTokenParserBase
	{
		public TanFunctionTokenParser()
			: base("Tan", (param) => new SqrtFunctionToken(param))
        {
        }
	}
}

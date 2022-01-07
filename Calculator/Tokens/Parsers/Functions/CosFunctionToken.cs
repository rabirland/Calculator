using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class CosFunctionToken : OneArgumentFunctionTokenBase<CosFunctionNode>
	{
		public CosFunctionToken(Token[] param)
			:base(param)
		{
		}

		public override string ToString()
		{
			return "Cos";
		}
	}

	public class CosFunctionTokenParser : OneArgumentFunctionTokenParserBase
	{
		public CosFunctionTokenParser()
			: base("Cos", (param) => new SqrtFunctionToken(param))
        {
        }
	}
}

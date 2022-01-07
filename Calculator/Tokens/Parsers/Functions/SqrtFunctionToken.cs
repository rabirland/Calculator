using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class SqrtFunctionToken : OneArgumentFunctionTokenBase<SqrtFunctionNode>
	{
		public SqrtFunctionToken(Token[] param)
			:base(param)
		{
		}

		public override string ToString()
		{
			return "Sqrt";
		}
	}

	public class SqrtFunctionTokenParser : OneArgumentFunctionTokenParserBase
	{
		public SqrtFunctionTokenParser()
			: base("sqrt", (param) => new SqrtFunctionToken(param))
        {
        }
	}
}

using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public class SinFunctionToken : OneArgumentFunctionTokenBase<SinFunctionNode>
	{
		public SinFunctionToken(Token[] param)
			:base(param)
		{
		}

		public override string ToString()
		{
			return "Sin";
		}
	}

	public class SinFunctionTokenParser : OneArgumentFunctionTokenParserBase
	{
		public SinFunctionTokenParser()
			: base("sin", (param) => new SqrtFunctionToken(param))
        {
        }
	}
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;
using System.Text.RegularExpressions;

namespace AdvancedCalculator.Tokens
{
	public class BracketToken : Token
	{
		Token[] subTokens;
		public BracketToken(Token[] subTokens)
		{
			this.subTokens = subTokens;
		}

		public override Node GetNode()
		{
			return new BracketNode(NodeBuilder.BuildTree(subTokens));
		}

		public override string ToString()
		{
			return "()";
		}
	}

	public class BracketTokenParser : ITokenParser
	{
		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (stream.Length == 0) return 0;
			if (stream[0] != '(') return 0;
			int endIndex = ParserHelper.FindNextTopLevelCloseBracket(stream, 1);

			if (endIndex < 0) throw new Exception("Closing bracket not found");

			string inside = stream.Substring(1, endIndex - 1);

			token = new BracketToken(parser.Parse(inside));
			return endIndex + 1;
		}
	}
}

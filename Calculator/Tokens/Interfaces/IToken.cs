using System;
using System.Collections.Generic;
using System.Text;

using AdvancedCalculator.Nodes;

namespace AdvancedCalculator.Tokens
{
	public abstract class Token
	{
		public abstract Node GetNode();
	}

	public interface ITokenParser
	{
		int TryParse(string stream, TokenParser parser, out Token token);
	}
}

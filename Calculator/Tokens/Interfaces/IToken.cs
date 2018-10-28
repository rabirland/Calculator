using System;
using System.Collections.Generic;
using System.Text;

using Calculator.Nodes;

namespace Calculator.Tokens
{
	public abstract class Token
	{
		public string Representative { get; private set; }

		public Token(string representative)
		{
			this.Representative = representative;
		}

		public abstract Node GetNode();
	}

	public interface ITokenParser
	{
		Token TryParse(string stream);
	}
}

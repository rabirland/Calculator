using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AdvancedCalculator.Nodes;
using System.Text.RegularExpressions;

namespace AdvancedCalculator.Tokens
{
	public class NumberToken : Token
	{
		decimal value;
		public NumberToken(decimal value)
		{
			this.value = value;
		}

		public override Node GetNode()
		{
			return new NumberNode(value);
		}

		public override string ToString()
		{
			return value.ToString(Calculator.NumberFormat);
		}
	}

	public class NumberTokenParser : ITokenParser
	{
		private static readonly char[] Numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		public int TryParse(string stream, TokenParser parser, out Token token)
		{
			token = null;
			if (stream.Length == 0) return 0;

			string value = "";
			bool foundDot = false;

			int i;
			for (i = 0; (i < stream.Length) && (Numbers.Contains(stream[i]) || (!foundDot && (foundDot = stream[i] == Constants.FractionSeparator))); i++)
				value += stream[i];

			if (i > 0) token = new NumberToken(decimal.Parse(value, Calculator.NumberFormat));
			return i;
		}
	}
}

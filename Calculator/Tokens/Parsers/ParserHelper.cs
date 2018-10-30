using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Tokens
{
    public static class ParserHelper
    {

		public static int FindNextTopLevelCloseBracket(string input, int startIndex)
		{
			if (input.Length == 0) return -1;
			int level = 0;

			for (int i = startIndex; i < input.Length; i++)
			{
				if (input[i] == Constants.OpenBracket) level++;
				if (input[i] == Constants.CloseBracket)
				{
					if (level > 0) level--;
					else
					{
						return i;
					}
				}
			}

			return -1;
		}

		public static int FindNextTopLevelParamSeparator(string input, int startIndex)
		{
			if (input.Length == 0) return -1;
			int level = 0;

			for (int i = startIndex; i < input.Length; i++)
			{
				if (input[i] == Constants.OpenBracket) level++;
				else if (input[i] == Constants.CloseBracket) level--;
				else if (input[i] == Constants.ParameterSeparator && level == 0)
				{
					return i;
				}
			}

			return -1;
		}

		public static string[] SplitParams(string input)
		{
			List<string> ret = new List<string>();

			int pos = 0;
			while (pos < input.Length)
			{
				int nextSeparator = FindNextTopLevelParamSeparator(input, pos);
				if (nextSeparator > 0)
				{
					ret.Add(input.Substring(pos, nextSeparator - pos));
					pos = nextSeparator + 1;
				}
				else
				{
					ret.Add(input.Substring(pos));
					pos = input.Length;
				}
			}

			return ret.ToArray();
		}
    }
}

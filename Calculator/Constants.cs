using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AdvancedCalculator
{
    static class Constants
    {
		public const char ParameterSeparator = ',';
		public const char FractionSeparator = '.';
		public const char AddOperator = '+';
		public const char SubtractOperator = '-';
		public const char MultiplyOperator = '*';
		public const char DivideOperator = '/';
		public const char PowerOperator = '^';
		public const char OpenBracket = '(';
		public const char CloseBracket = ')';

		public static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo() { NumberDecimalSeparator = FractionSeparator.ToString() };

		#region Shorteneds

		/// <summary>
		/// Parameter separator
		/// </summary>
		public const char PS = ParameterSeparator;

		/// <summary>
		/// Fraction separator
		/// </summary>
		public const char FS = FractionSeparator;

		#endregion
	}
}

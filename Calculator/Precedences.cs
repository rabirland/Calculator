﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator
{
	static class Precedences
	{
		public const int PlusMinus = 100;

		public const int MultiplyDivide = 80;

		public const int ExponentsRoots = 70;

		public const int UnaryPlusMinus = 60;

		public const int Factorial = 60;
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	public sealed class PowerOperatorNode : InfixOperatorBase
	{
		public override decimal GetValue()
		{
			return (decimal)Math.Pow((double)this.Left.GetValue(), (double)this.Right.GetValue());
		}

		public override string ToString()
		{
			return $"{this.Left} ^ {this.Right}";
		}

		public override int Precedence => Precedences.ExponentsRoots;
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	class MultiplyNode : InfixOperatorBase
	{
		public override decimal GetValue()
		{
			if (this.Right == null) throw new NullNodeException();
			if (this.Left == null) throw new NullNodeException();

			return Left.GetValue() * Right.GetValue();
		}

		public override string ToString()
		{
			return $"{this.Left} * {this.Right}";
		}

		public override int Precedence => Precedences.MultiplyDivide;
	}
}

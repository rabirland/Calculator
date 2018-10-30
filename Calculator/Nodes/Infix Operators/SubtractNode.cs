using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	class SubtractNode : InfixOperatorBase
	{
		public override decimal GetValue()
		{
			if (this.Left == null && this.Right != null) return -this.Right.GetValue();
			else if (this.Right == null) throw new NullNodeException();
			else return Left.GetValue() - Right.GetValue();
		}

		public override string ToString()
		{
			return $"{this.Left} - {this.Right}";
		}

		public override Node Optimize()
		{
			if (this.Left == null && this.Right != null && this.Right is NumberNode)
			{
				NumberNode ret = (NumberNode)this.Right;
				return new NumberNode(-ret.GetValue()); //Return a new Numbernode with negative value
			}
			else return this;
		}

		public override int Precedence => Precedences.PlusMinus;
	}
}

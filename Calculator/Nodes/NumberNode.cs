using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
    class NumberNode : UnaryNode
    {
		decimal Value { get; set; }

		public NumberNode(decimal value)
		{
			this.Value = value;
		}

		public override decimal GetValue()
		{
			return this.Value;
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}
	}
}

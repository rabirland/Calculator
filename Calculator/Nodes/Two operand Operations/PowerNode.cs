using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	class PowerNode : TwoOperandOperatorUnaryLeftBase
	{
		public override decimal GetValue()
		{
			return 0m;
		}

		public override string ToString()
		{
			return $"POW({this.Left}, {this.Right})";
		}

		public override int Precedence => Precedences.ExponentsRoots;
	}
}

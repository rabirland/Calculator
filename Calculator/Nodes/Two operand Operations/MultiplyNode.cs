﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	class MultiplyNode : TwoOperandOperatorBase
	{
		public MultiplyNode(Node left, Node right)
		{
			this.Left = left;
			this.Right = right;
		}

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
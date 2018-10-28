using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	public abstract class Node
	{
		public Node Parent { get; internal set; }

		public abstract decimal GetValue();
	}

	public abstract class UnaryNode : Node
	{

	}
}

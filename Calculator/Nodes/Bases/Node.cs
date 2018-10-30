using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	public abstract class Node
	{
		public Node Parent { get; internal set; }

		public abstract decimal GetValue();

		public virtual Node Optimize() => this;
	}

	public abstract class UnaryNode : Node
	{

	}
}

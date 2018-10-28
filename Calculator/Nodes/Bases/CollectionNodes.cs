using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	public abstract class UnaryCollectionNode : UnaryNode, ICollectionNode
	{
		public Node Child { get; private set; }

		public UnaryCollectionNode(Node child)
		{
			this.Child = child;
		}

		public Node this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return this.Child;
					default: throw new IndexOutOfRangeException();
				}
			}

			set
			{
				switch (index)
				{
					case 0:
						value.Parent = this;
						this.Child = value;
						break;
					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public override decimal GetValue()
		{
			return this.Child.GetValue();
		}

		public int Length => 1;
	}
}

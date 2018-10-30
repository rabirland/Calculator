using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
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

		public int GetIndex(Node node)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));

			if (this.Child != null && this.Child == node) return 0;
			else return -1;
		}

		public override decimal GetValue()
		{
			return this.Child.GetValue();
		}

		public int Length => 1;

		public bool CanAdd(Node node, int index) => true;

		public void BeforeAdd(Node node, int index)
		{

		}
	}
}

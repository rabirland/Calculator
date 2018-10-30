using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	public abstract class InfixOperatorBase : Node, IOperatorNode, IPrecedenceFixer
	{
		public Node Left { get; private set; }
		public Node Right { get; private set; }

		public Node this[int index]
		{
			get
			{
				switch(index)
				{
					case 0: return this.Left;
					case 1: return this.Right;
					default: throw new IndexOutOfRangeException();
				}
			}

			set
			{
				if (value != null && value.Parent != null) throw new Exception("The node already has a parent");

				switch (index)
				{
					case 0:
						if (this.Left != null && this.Left != value) this.Left.Parent = null; //Remove parent entry
						if (value != null) value.Parent = this;
						this.Left = value;
						break;
					case 1:
						if (this.Right != null && this.Right != value) this.Right.Parent = null; //Remove parent entry
						if (value != null) value.Parent = this;
						this.Right = value;
						break;
					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public int GetIndex(Node node)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));

			if (this.Left != null && node == this.Left) return 0;
			else if (this.Right != null && node == this.Right) return 1;
			return -1;
		}

		public int Length { get => 2; }

		public abstract int Precedence { get; }

		public virtual void BeforeAdd(Node node, int index)
		{

		}

		internal void SwapWithChild(int childIndex, int targetIndex)
		{
			ICollectionNode coll = this[childIndex] as ICollectionNode;
			if (coll == null) throw new Exception("The given child is not a collection");

			Node child = this[childIndex];

			//Save the child's child
			Node tmp = coll[targetIndex];

			//Add the child to the old parent of this
			this[childIndex] = null; //Un-parent child from this
			ICollectionNode parent = this.Parent != null ? (ICollectionNode)this.Parent : null;
			if (parent != null)
			{
				int thisIndex = parent.GetIndex(this);
				parent[thisIndex] = child;
			}

			//Set this as child of old child
			coll[targetIndex] = this;

			//Set the tmp as new child
			this[childIndex] = tmp;
		}

		public Node FixPrecedence()
		{
			Node left = this[0];
			Node right = this[1];

			InfixOperatorBase leftOp = left as InfixOperatorBase;
			InfixOperatorBase rightOp = right as InfixOperatorBase;

			int leftPrec = leftOp?.Precedence ?? -1;
			int rightPrec = rightOp?.Precedence ?? -1;

			if (leftPrec > this.Precedence && rightPrec > this.Precedence) //The parent (op) must be put "between" the two child
			{

			}
			else if (leftPrec > this.Precedence) //The parent (op) comes after the left child
			{
				Node child = this[0];
				this.SwapWithChild(0, 1);
				return child;

			}
			else if (rightPrec > this.Precedence) //The parent (op) comes before the right child
			{
				Node child = this[1];
				this.SwapWithChild(1, 0);
				return child;
			}
			return this;
		}
	}
}

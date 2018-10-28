using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	public abstract class OneOperandOperatorBase : Node, ICollectionNode, IOperatorNode
	{
		public Node Child { get; private set; }

		public OneOperandOperatorBase(Node child)
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

		public int Length { get => 1; }

		public abstract int Precedence { get; }
	}

	public abstract class TwoOperandOperatorBase : Node, ICollectionNode, IOperatorNode
	{
		public Node Left;
		public Node Right;

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
				switch (index)
				{
					case 0:
						value.Parent = this;
						this.Left = value;
						break;
					case 1:
						value.Parent = this;
						this.Right = value;
						break;
					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public int Length { get => 2; }

		public abstract int Precedence { get; }
	}

	public abstract class TwoOperandOperatorUnaryLeftBase : Node, ICollectionNode, IOperatorNode
	{
		public UnaryNode Left;
		public Node Right;

		public Node this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return this.Left;
					case 1: return this.Right;
					default: throw new IndexOutOfRangeException();
				}
			}

			set
			{
				switch (index)
				{
					case 0:
						value.Parent = this;
						this.Left = (UnaryNode)value;
						break;
					case 1:
						value.Parent = this;
						this.Right = value;
						break;
					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public int Length { get => 2; }

		public abstract int Precedence { get; }
	}

	public abstract class ThreeOperandOperatorBase : Node, ICollectionNode, IOperatorNode
	{
		public Node First;
		public Node Second;
		public Node Third;

		public Node this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return this.First;
					case 1: return this.Second;
					case 2: return this.Third;

					default: throw new IndexOutOfRangeException();
				}
			}

			set
			{
				switch (index)
				{
					case 0:
						value.Parent = this;
						this.First = value;
						break;
					case 1:
						value.Parent = this;
						this.Second = value;
						break;
					case 3:
						value.Parent = this;
						this.Third = value;
						break;

					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public int Length { get => 3; }

		public abstract int Precedence { get; }
	}
}

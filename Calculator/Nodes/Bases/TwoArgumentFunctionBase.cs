using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	public abstract class TwoArgumentFunctionBase : Node, ICollectionNode
	{
		public Node First { get; private set; }
		public Node Second { get; private set; }

		public Node this[int index]
		{
			get
			{
				switch(index)
				{
					case 0: return this.First;
					case 1: return this.Second;
					default: throw new IndexOutOfRangeException();
				}
			}

			set
			{
				if (value != null && value.Parent != null) throw new Exception("The node already has a parent");

				switch (index)
				{
					case 0:
						if (this.First != null && this.First != value) this.First.Parent = null; //Remove parent entry
						if (value != null) value.Parent = this;
						this.First = value;
						break;
					case 1:
						if (this.Second != null && this.Second != value) this.Second.Parent = null; //Remove parent entry
						if (value != null) value.Parent = this;
						this.Second = value;
						break;
					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public int GetIndex(Node node)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));

			if (this.First != null && node == this.First) return 0;
			else if (this.Second != null && node == this.Second) return 1;
			return -1;
		}

		public int Length { get => 2; }

		public virtual void BeforeAdd(Node node, int index)
		{

		}
	}
}

using System;

namespace AdvancedCalculator.Nodes
{
	public abstract class OneArgumentFunctionBase : Node, ICollectionNode
	{
		public Node Parameter { get; private set; }

		public Node this[int index]
		{
			get
			{
				switch(index)
				{
					case 0: return this.Parameter;
					default: throw new IndexOutOfRangeException();
				}
			}

			set
			{
				if (value != null && value.Parent != null) throw new Exception("The node already has a parent");

				switch (index)
				{
					case 0:
						if (this.Parameter != null && this.Parameter != value) this.Parameter.Parent = null; //Remove parent entry
						if (value != null) value.Parent = this;
						this.Parameter = value;
						break;
					default: throw new IndexOutOfRangeException();
				}
			}
		}

		public int GetIndex(Node node)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));

			if (this.Parameter != null && node == this.Parameter) return 0;
			return -1;
		}

		public int Length { get => 1; }

		public virtual void BeforeAdd(Node node, int index)
		{

		}
	}
}

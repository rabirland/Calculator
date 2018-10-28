using System;
using System.Collections.Generic;
using System.Text;

using Calculator.Nodes;

namespace Calculator
{
    class Calculator
    {
		public Node Root { get; set; }

		public Node GetNode(int[] path)
		{
			if (path == null) throw new ArgumentNullException(nameof(path));
			if (path.Length == 0) return this.Root;
			if (!(this.Root is ICollectionNode)) throw new InvalidPathException();

			ICollectionNode current = (ICollectionNode)this.Root;

			for (int i = 0; i < path.Length; i++)
			{
				if (i < path.Length - 1)
				{
					Node next = current[path[i]];

					if (!(next is ICollectionNode)) throw new InvalidPathException();
					current = (ICollectionNode)next;
				}
				else
				{
					return current[path[i]];
				}
			}

			throw new InvalidPathException();
		}

		public void SetNode(int[] path, Node node)
		{
			if (path == null) throw new ArgumentNullException(nameof(path));
			if (path.Length == 0)
			{
				this.Root = node;
				return;
			}
			if (!(this.Root is ICollectionNode)) throw new InvalidPathException();

			ICollectionNode current = (ICollectionNode)this.Root;

			for (int i = 0; i < path.Length; i++)
			{
				if (i < path.Length - 1)
				{
					Node next = current[path[i]];

					if (!(next is ICollectionNode)) throw new InvalidPathException();
					current = (ICollectionNode)next;
				}
				else
				{
					current[path[i]] = node;
					return;
				}
			}

			throw new InvalidPathException();
		}

		public void ReplaceAsParent(int[] path, ICollectionNode collectionNode, int childIndex)
		{
			if (path == null) throw new ArgumentNullException(nameof(path));
			if (collectionNode == null) throw new ArgumentNullException(nameof(collectionNode));
			if (!(collectionNode is Node)) throw new ArgumentException("The given node is not a Calculator Node");

			//Get the current parent of the Old node
			int[] targetParentPath = new int[path.Length - 1];
			Array.Copy(path, targetParentPath, targetParentPath.Length);
			ICollectionNode targetParent = (ICollectionNode)this.GetNode(targetParentPath);

			//Set the old element as the child of the new
			collectionNode[childIndex] = targetParent[path[path.Length - 1]];

			//Set the new element as the child of the old's parent
			targetParent[path[path.Length - 1]] = (Node)collectionNode;
		}

		public decimal GetValue()
		{
			return this.Root.GetValue();
		}

		public override string ToString()
		{
			return this.Root?.ToString();
		}
	}
}

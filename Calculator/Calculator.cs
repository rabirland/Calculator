using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using AdvancedCalculator.Nodes;
using AdvancedCalculator.Tokens;

namespace AdvancedCalculator
{
    public class Calculator
    {
		public static NumberFormatInfo NumberFormat => Constants.NumberFormat; 

		public Node Root { get; set; }
		TokenParser tokenParser;

		public Calculator()
		{
			tokenParser = new TokenParser();
		}

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

		public void ReplaceAsParent(int[] path, Node node, int childIndex)
		{
			if (path == null) throw new ArgumentNullException(nameof(path));
			if (!(node is ICollectionNode)) throw new Exception("Invalid node");
			ICollectionNode collectionNode = (ICollectionNode)node;
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

		public void Parse(string input)
		{
			input = string.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
			Token[] tokens = this.tokenParser.Parse(input);
			this.Root = NodeBuilder.BuildTree(tokens);
			this.Optimize();
			this.FixPrecedence();
		}

		public void FixPrecedence()
		{
			this.Root = FixPrecedence(this.Root);
		}

		public void Optimize()
		{
			this.Root = OptimizeInternal(this.Root);
		}

		private Node FixPrecedence(Node node)
		{
			if (node is ICollectionNode)
			{
				ICollectionNode op = (ICollectionNode)node;
				//First, fix precedence of childs
				for (int i = 0; i < op.Length; i++)
				{
					if (op[i] != null)
					{
						FixPrecedence(op[i]);
					}
				}
			}

			//Then the current one
			if (node is IPrecedenceFixer)
				return ((IPrecedenceFixer)node).FixPrecedence();
			else return node;
		}

		private Node OptimizeInternal(Node node)
		{
			if (node is ICollectionNode)
			{
				ICollectionNode op = (ICollectionNode)node;
				//First, fix precedence of childs
				for (int i = 0; i < op.Length; i++)
				{
					if (op[i] != null)
					{
						Node optimizedChild = OptimizeInternal(op[i]);
						if (optimizedChild != op[i])
							op[i] = optimizedChild;
					}
				}
			}

			//Then the current one
			Node optimized = node.Optimize();
			return optimized;
		}

		public override string ToString()
		{
			return this.Root?.ToString();
		}
	}
}

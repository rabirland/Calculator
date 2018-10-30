using System;
using System.Collections.Generic;
using System.Text;

using AdvancedCalculator.Tokens;

namespace AdvancedCalculator.Nodes
{
	public class NodeBuilder
	{
		public static Node BuildTree(Token[] tokens)
		{
			Node root = null;

			if (tokens == null) throw new ArgumentNullException(nameof(tokens));
			if (tokens.Length == 0) throw new ArgumentException("The given token array must not be empty");

			for (int i = 0; i < tokens.Length; i++)
			{
				Token token = tokens[i];
				if (token == null) throw new Exception("The token array must not contain null entries");

				Node tokenNode = token.GetNode();

				if (root == null) root = tokenNode; //If there is no root yet => create it.
				else
				{
					if (FindEmptyLast(root, out IOperatorNode child, out int index)) //If not an operator => Find the last (right-most) empty slot in the tree.
					{
						child[index] = tokenNode;
					}
					else if (tokenNode is IOperatorNode)
					{
						IOperatorNode node = (IOperatorNode)tokenNode;
						node[0] = root;
						root = tokenNode;
					}
					else
					{
						//TODO
						throw new Exception("TODO: Add a fancy-ass error message here...");
					}
				}
			}

			return root;
		}

		private static bool FindEmptyLast(Node node, out IOperatorNode parent, out int index)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));
			index = -1;
			parent = null;
			if (!(node is IOperatorNode)) return false;

			IOperatorNode coll = (IOperatorNode)node;

			if (coll[coll.Length - 1] == null)
			{
				parent = coll;
				index = coll.Length - 1;
				return true;
			}
			else return FindEmptyLast(coll[coll.Length - 1], out parent, out index);
		}

		private static bool FindFreeSlot(Node node, out ICollectionNode parent, out int index, bool forward = true)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));
			index = -1;
			parent = null;
			if (!(node is ICollectionNode)) return false;

			ICollectionNode coll = (ICollectionNode)node;

			//TODO: Remove code duplication
			if (forward)
			{
				for (int i = 0; i < coll.Length; i++)
				{
					if (coll[i] == null)
					{
						index = i;
						parent = coll;
						return true;
					}
					else if (coll[i] is ICollectionNode && FindFreeSlot(coll[i], out parent, out index)) //Recursively look in childs
					{
						return true;
					}
				}
			}
			else
			{
				for (int i = coll.Length - 1; i >= 0; i--)
				{
					if (coll[i] == null)
					{
						index = i;
						parent = coll;
						return true;
					}
					else if (coll[i] is ICollectionNode && FindFreeSlot(coll[i], out parent, out index)) //Recursively look in childs
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
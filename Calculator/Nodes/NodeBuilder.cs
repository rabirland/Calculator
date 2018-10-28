using System;
using System.Collections.Generic;
using System.Text;

using Calculator.Tokens;

namespace Calculator.Nodes
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
					if (FindFreeSlot(root, out ICollectionNode child, out int index)) //Find the first empty slot in the current tree
					{
						child[index] = tokenNode;
					}
					else if (tokenNode is ICollectionNode && FindFreeSlot(tokenNode, out child, out index)) //If there is no empty slots in the tree and the new node is a collection => make it root
					{
						child[index] = root; //Make the current root as child
						root = tokenNode; //Register a new root
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

		private static bool FindFreeSlot(Node node, out ICollectionNode parent, out int index)
		{
			if (node == null) throw new ArgumentNullException(nameof(node));
			index = -1;
			parent = null;
			if (!(node is ICollectionNode)) return false;

			ICollectionNode coll = (ICollectionNode)node;

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

			return false;
		}

		public static void ReorderByPrecedence(Node root)
		{

		}

		private static void SwapPrecedence()
		{

		}
	}
}

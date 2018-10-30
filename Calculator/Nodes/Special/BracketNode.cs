﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	class BracketNode : UnaryCollectionNode
	{
		public BracketNode(Node child) : base(child)
		{

		}

		public override string ToString()
		{
			return $"({this.Child})";
		}
	}
}

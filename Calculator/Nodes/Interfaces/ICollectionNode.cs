using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	interface ICollectionNode
	{
		Node this[int index] { get; set; }

		int Length { get; }
	}
}

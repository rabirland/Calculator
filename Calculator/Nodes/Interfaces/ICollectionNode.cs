using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	public interface ICollectionNode
	{
		Node this[int index] { get; set; }

		int GetIndex(Node node);

		int Length { get; }

		void BeforeAdd(Node node, int index);
	}
}

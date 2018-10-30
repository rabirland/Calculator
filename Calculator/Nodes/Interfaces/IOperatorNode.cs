using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	interface IOperatorNode : ICollectionNode
	{
		int Precedence { get; }
	}

	interface IPrecedenceFixer
	{
		Node FixPrecedence();
	}
}

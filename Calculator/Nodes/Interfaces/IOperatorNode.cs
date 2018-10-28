using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Nodes
{
	interface IOperatorNode
	{
		int Precedence { get; }
	}
}

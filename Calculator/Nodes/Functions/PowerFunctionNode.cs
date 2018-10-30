using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCalculator.Nodes
{
	public sealed class PowerFunctionNode : TwoArgumentFunctionBase
	{
		public override decimal GetValue()
		{
			return (decimal)Math.Pow((double)this.First.GetValue(), (double)this.Second.GetValue());
		}

		public override string ToString()
		{
			return $"Pow({this.First}, {this.Second})";
		}
	}
}

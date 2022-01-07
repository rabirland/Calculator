using System;

namespace AdvancedCalculator.Nodes
{
	public sealed class TanFunctionNode : OneArgumentFunctionBase
	{
		public override decimal GetValue()
		{
			return (decimal)Math.Tan((double)this.Parameter.GetValue());
		}

		public override string ToString()
		{
			return $"Tan({this.Parameter})";
		}
	}
}

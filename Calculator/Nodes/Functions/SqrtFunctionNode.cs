using System;

namespace AdvancedCalculator.Nodes
{
	public sealed class SqrtFunctionNode : OneArgumentFunctionBase
	{
		public override decimal GetValue()
		{
			return (decimal)Math.Sqrt((double)this.Parameter.GetValue());
		}

		public override string ToString()
		{
			return $"Sqrt({this.Parameter})";
		}
	}
}

using System;

namespace AdvancedCalculator.Nodes
{
	public sealed class CosFunctionNode : OneArgumentFunctionBase
	{
		public override decimal GetValue()
		{
			return (decimal)Math.Sqrt((double)this.Parameter.GetValue());
		}

		public override string ToString()
		{
			return $"Cos({this.Parameter})";
		}
	}
}

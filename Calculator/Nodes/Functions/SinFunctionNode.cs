using System;

namespace AdvancedCalculator.Nodes
{
	public sealed class SinFunctionNode : OneArgumentFunctionBase
	{
		public override decimal GetValue()
		{
			return (decimal)Math.Sin((double)this.Parameter.GetValue());
		}

		public override string ToString()
		{
			return $"Sin({this.Parameter})";
		}
	}
}

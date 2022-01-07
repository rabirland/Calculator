using System;

using AdvancedCalculator;
using AdvancedCalculator.Nodes;
using AdvancedCalculator.Tokens;

namespace TEST2
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.Write("Expression: ");
			string input = "";


			AdvancedCalculator.Calculator calc = new AdvancedCalculator.Calculator();

			while (!string.IsNullOrEmpty(input = Console.ReadLine()))
			{

				calc.Parse(input);
				Console.WriteLine($"Result: {calc.GetValue().ToString(AdvancedCalculator.Calculator.NumberFormat)}");

				Console.Write("Expression: ");
			}
        }
    }
}

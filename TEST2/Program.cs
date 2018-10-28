using System;

using Calculator;
using Calculator.Nodes;
using Calculator.Tokens;

namespace TEST2
{
    class Program
    {
        static void Main(string[] args)
        {
			TokenParser tokenStream = new TokenParser();

			string stream = "1+2*3+4";

			Token[] tokens = tokenStream.Parse(stream);

			Node node = NodeBuilder.BuildTree(tokens);


			Console.WriteLine("-= DONE =-");
			Console.ReadLine();
        }
    }
}

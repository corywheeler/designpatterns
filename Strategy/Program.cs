using System;
using Strategy.Calculate;

namespace Strategy
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			CalculateClient client = new CalculateClient();

			client.SetCalculate(new Minus());
			Console.WriteLine("Minus: " + client.Calculate(8, 2));

			client.SetCalculate(new Plus());
			Console.WriteLine("Plus: " + client.Calculate(7, 2));
		}
	}
}
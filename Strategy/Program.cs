using System;

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
			Console.WriteLine("Plus: " + client.Calculate(3, 2));
		}
	}

	public class CalculateClient
	{
		private ICalculate strategy;

		public int Calculate(int value1, int value2)
		{
			return strategy.Calculate(value1, value2);
		}

		public void SetCalculate(ICalculate strategy)
		{
			this.strategy = strategy;
		}
	}

	public interface ICalculate
	{
		int Calculate(int value1, int value2);
	}

	public class Plus : ICalculate
	{
		public int Calculate(int value1, int value2)
		{
			return value1 + value2;
		}
	}

	public class Minus : ICalculate
	{
		public int Calculate(int value1, int value2)
		{
			return value1 - value2;
		}
	}
}

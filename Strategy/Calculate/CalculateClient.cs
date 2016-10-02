namespace Strategy.Calculate
{
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
}
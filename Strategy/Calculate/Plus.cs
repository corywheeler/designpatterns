namespace Strategy.Calculate
{
	public class Plus : ICalculate
	{
		public int Calculate(int value1, int value2)
		{
			return value1 + value2;
		}
	}
}
namespace Strategy.Calculate
{
	public class Minus : ICalculate
	{
		public int Calculate(int value1, int value2)
		{
			return value1 - value2;
		}
	}
}
using System;

namespace Flyweight
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			const int ONE_THOUSAND = 1000;
			int[] currencyDenominations = new[] {1, 5, 10, 20, 50, 100 };
			MoneyFactory moneyFactory = new MoneyFactory();
			int sum = 0;

			while (sum <= ONE_THOUSAND)
			{
				IMoney graphicalMoneyObj = null;
				Random rand = new Random();
				int currencyDisplayValue = currencyDenominations[rand.Next(0, currencyDenominations.Length)];

				if (currencyDisplayValue == 1 || currencyDisplayValue == 5)
				{
					graphicalMoneyObj = moneyFactory.GetMoneyToDisplay(EnMoneyType.Metallic);
				}
				else 
				{
					graphicalMoneyObj = moneyFactory.GetMoneyToDisplay(EnMoneyType.Paper);
				}

				graphicalMoneyObj.GetDisplayOfMoneyFalling(currencyDisplayValue);
				sum += 1;
			}

			Console.WriteLine("Total Objects Created = " + MoneyFactory.ObjectsCount.ToString());
			Console.ReadLine();
		}
	}
}

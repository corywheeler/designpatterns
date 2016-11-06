using System;

namespace Flyweight
{
	public class PaperMoney: IMoney
	{
		public PaperMoney()
		{
		}

		public EnMoneyType MoneyType // Get Intrinsic State
		{
			get
			{
				return EnMoneyType.Paper;
			}
		}

		public void GetDisplayOfMoneyFalling(int moneyValue) // Get Extrensic State
		{
			// This would display the graphical representation of paper money like a dollar.
			Console.WriteLine("Displaying a graphical object of {0} currency of value ${1} falling from the sky.",
							  MoneyType.ToString(), moneyValue);
		}
	}
}

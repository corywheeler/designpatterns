using System;

namespace Flyweight
{
	public class MetallicMoney: IMoney
	{
		public MetallicMoney()
		{
		}

		public EnMoneyType MoneyType // Get Intrinsic State
		{
			get
			{
				return EnMoneyType.Metallic;
			}
		}

		public void GetDisplayOfMoneyFalling(int moneyValue) // Get Extrensic State
		{
			// This would display the graphical representation of metallic money like a gold coin.
			Console.WriteLine("Displaying a graphical object of {0} currency of value ${1} falling from the sky.",
							  MoneyType.ToString(), moneyValue);
		}
	}
}

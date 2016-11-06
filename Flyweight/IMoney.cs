namespace Flyweight
{
	// This is the Flyweight Interface
	public interface IMoney
	{
		EnMoneyType MoneyType { get; } // Instrinsic State
		void GetDisplayOfMoneyFalling(int moneyValue); // Get Extrensic State
	}
}

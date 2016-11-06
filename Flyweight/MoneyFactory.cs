using System.Collections.Generic;
namespace Flyweight
{
	public class MoneyFactory  // Flyweight Factory
	{

		public static int ObjectsCount = 0;
		private Dictionary<EnMoneyType, IMoney> _moneyObjects;

		public IMoney GetMoneyToDisplay(EnMoneyType form)
		{
			if (_moneyObjects == null)
			{
				_moneyObjects = new Dictionary<EnMoneyType, IMoney>();
			}

			if (_moneyObjects.ContainsKey(form))
			{
				return _moneyObjects[form];
			}

			switch (form)
			{
				case EnMoneyType.Metallic:
					_moneyObjects.Add(form, new MetallicMoney());
					ObjectsCount++;
					break;
				case EnMoneyType.Paper:
					_moneyObjects.Add(form, new PaperMoney());
					ObjectsCount++;
					break;
				default:
					break;
			}

			return _moneyObjects[form];
		}
	}
}

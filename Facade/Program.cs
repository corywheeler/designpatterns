using Facade.Builders;

namespace Facade
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var carBuilder = new CarBuilder();
			carBuilder.CreateCompleteCar();
		}
	}
}
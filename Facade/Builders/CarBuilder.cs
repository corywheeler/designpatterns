using Facade.Models;
using Facade.Engines;
using Facade.Bodies;
using Facade.Accessories;

namespace Facade.Builders
{
	public class CarBuilder
	{
		private readonly CarModel model;
		private readonly CarEngine engine;
		private readonly CarBody body;
		private readonly CarAccessories accessories;

		public CarBuilder()
		{
		}
	}
}

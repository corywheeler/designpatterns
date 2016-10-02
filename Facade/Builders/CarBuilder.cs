using Facade.Models;
using Facade.Engines;
using Facade.Bodies;
using Facade.Accessories;
using System;

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
			model = new CarModel();
			engine = new CarEngine();
			body = new CarBody();
			accessories = new CarAccessories();
		}

		public void CreateCompleteCar()
		{
			Console.WriteLine("******** Creating a Car. **********");
			model.SetModel();
			engine.SetEngine();
			body.SetBody();
			accessories.SetAccessories();
			Console.WriteLine("******** Car creation is completed. **********");
		}
	}
}

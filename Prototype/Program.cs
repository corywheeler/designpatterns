using System;
using System.Collections.Generic;

namespace Prototype
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var prototypeList = new List<string>() { "tom", "dick", "harry", "Dick", "Tom", "Harry" };

			prototypeList.ForEach(name => {
				var person = Factory.MakeObject(name);
				Console.WriteLine(person + " is " + person.Age());
			});
		}
	}
}
using System;

namespace Prototype
{
	public class Tom: PersonWithAge
	{
		int _age;

		public Tom(int age)
		{
			_age = age;
		}

		public int Age()
		{
			return _age;
		}

		public PersonWithAge cloan()
		{
			return new Tom(_age);
		}

		public override string ToString()
		{
			return "Tom";
		}
	}
}
namespace Prototype
{
	public class Harry : PersonWithAge
	{
		int _age;

		public Harry(int age)
		{
			_age = age;
		}

		public int Age()
		{
			return _age;
		}

		public PersonWithAge cloan()
		{
			return new Harry(_age);
		}

		public override string ToString()
		{
			return "Harry";
		}
	}
}
namespace Prototype
{
	public class Dick: PersonWithAge
	{
		int _age;

		public Dick(int age)
		{
			_age = age;
		}

		public int Age()
		{
			return _age;
		}

		public PersonWithAge cloan()
		{
			return new Dick(_age);
		}

		public override string ToString()
		{
			return "Dick";
		}
	}
}
using System.Collections.Generic;
            
namespace Prototype
{
	public static class Factory
	{
		static IDictionary<string, PersonWithAge> prototypes = new Dictionary<string, PersonWithAge>();

		static Factory()
		{
			prototypes.Add("tom", new Tom(25));
			prototypes.Add("Tom", new Tom(35));
			prototypes.Add("dick", new Dick(55));
			prototypes.Add("Dick", new Dick(40));
			prototypes.Add("harry", new Harry(32));
			prototypes.Add("Harry", new Harry(16));
		}

		public static PersonWithAge MakeObject(string whichInstance)
		{
			return prototypes[whichInstance].cloan();
		}
	}
}
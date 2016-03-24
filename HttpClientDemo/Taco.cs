using System;

namespace TacoDemo
{
	public class Taco
	{
		public int id { get; set; }
		public string name { get; set; }
		public string meat { get; set; }
		public int layers { get; set; }
		public int calories { get; set; }
		public bool has_cheese { get; set; }
		public bool has_lettuce { get; set; }
		public string details { get; set; }

		public string Summary {
			get{ return String.Format ("Name: {0}, Meat: {1}", name, meat); }
		}

		public override string ToString ()
		{
			return String.Format ("{0}, {1}, {2}, {3}", name, meat, calories, details);
		}
	}

	public class Rootobject
	{
		public Taco[] tacos { get; set; }
	}
}


using System;
using System.ComponentModel.DataAnnotations;

namespace SqlAPITest.Entity
{
	public class Product
	{
		[Key]
		public int ID { get; set; }

		public string? Name { get; set; }

		public int Price { get; set; }
	}
}


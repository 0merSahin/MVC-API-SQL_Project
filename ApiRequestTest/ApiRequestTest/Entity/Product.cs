using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRequestTest.Entity
{
	public class Product
	{
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "string")]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public int? Price { get; set; }
    }
}


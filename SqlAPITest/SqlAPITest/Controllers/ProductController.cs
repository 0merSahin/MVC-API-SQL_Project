using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlAPITest.Concrete;
using SqlAPITest.Entity;

namespace SqlAPITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ProductController(SqlDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var product = _context.Products.ToList();
            return Ok(product);
        }


        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
            }
            else
                return BadRequest();
        }
    }
}


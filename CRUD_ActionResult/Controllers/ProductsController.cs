using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_ActionResult.Models;

namespace CRUD_ActionResult.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1006368,
                Name = "Austin and Barbeque AABQ WiFi Food Thermometer",
                Description = "Thermometer med WiFi för en optimal innertemperatur",
                Price = 399
            },
            new Product
            {
                Id = 1009334,
                Name = "Anderson Elektrisk Tändare ECL 1.1",
                Description = "Elektrisk stormsäker tändare helt utan gas och bränsle",
                Price = 89
            },
            new Product
            {
                Id = 1002266,
                Name = "Weber Non-Stick Spray",
                Price = 99
            }
        };

        // Get All Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        //Get specific product
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.Find(product => product.Id == id);
            return product;
        }

        // Add new product
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            products.Add(product);
        }

        //Delete Product
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            products = products.Except(product).ToList();
        }

        // Update product
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();

            products.Add(product);
        }


    }


}

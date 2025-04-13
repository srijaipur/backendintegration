
using Microsoft.AspNetCore.Mvc;
 using System.Collections.Generic;
 using System.Linq;

 namespace BlazorAPI.Controllers
 {
     [Route("api/[controller]")]
     [ApiController]
     public class ProductController : ControllerBase
     {
         private static List<Product> products = new List<Product>
         {
             new Product { Id = 1, Name = "Product1", Price = 10.0m },
             new Product { Id = 2, Name = "Product2", Price = 20.0m }
         };

         // GET: api/product
         [HttpGet]
         public ActionResult<IEnumerable<Product>> GetProducts()
         {
             return products;
         }

         // GET: api/product/1
         [HttpGet("{id}")]
         public ActionResult<Product> GetProduct(int id)
         {
             var product = products.FirstOrDefault(p => p.Id == id);
             if (product == null)
             {
                 return NotFound();
             }
             return product;
         }

         // POST: api/product
         [HttpPost]
         public ActionResult<Product> CreateProduct(Product product)
         {
             product.Id = products.Count + 1;
             products.Add(product);
             return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
         }

         // PUT: api/product/1
         [HttpPut("{id}")]
         public IActionResult UpdateProduct(int id, Product product)
         {
             var existingProduct = products.FirstOrDefault(p => p.Id == id);
             if (existingProduct == null)
             {
                 return NotFound();
             }
             existingProduct.Name = product.Name;
             existingProduct.Price = product.Price;
             return NoContent();
         }

         // DELETE: api/product/1
         [HttpDelete("{id}")]
         public IActionResult DeleteProduct(int id)
         {
             var product = products.FirstOrDefault(p => p.Id == id);
             if (product == null)
             {
                 return NotFound();
             }
             products.Remove(product);
             return NoContent();
         }
     }
 }

using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            if (!_context.Products.Any())
            {

                List<Product> samples = Enumerable.Range(1, 5).Select(index => new Product
                {
                    Id = "Id" + index,
                    Description = "Description" + index,
                    Price = 5 * index,
                    Quantity = index
                }).ToList();
                _context.Products.AddRange(samples);
                _context.SaveChanges();
            }
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToArray();
        }

        [HttpPost(Name = "AddProduct")]
        public void Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpGet("{upc}", Name = "GetProductByUPC")]
        public Product Get(string upc)
        {
            return _context.Products.FirstOrDefault(p => p.Id == upc) ?? NoProduct(upc);
        }

        private static Product NoProduct(string upc)
        {
            return new Product
            {
                Id = upc,
                Description = "No product found",
                Price = 0.0f,
                Quantity = 0
            };
        }

        [HttpPost("{upc}", Name = "UpdateProduct")]
        public void Post(string upc, Product product)
        {
            if (product.Id != upc)
            {
                throw new ArgumentException("Product Id does not match the URL parameter.");
            }
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        [HttpDelete("{upc}", Name = "DeleteProduct")]
        public void Delete(string upc)
        {
            _context.Products.Remove(_context.Products.First(p => p.Id == upc));
            _context.SaveChanges();
        }
    }
}

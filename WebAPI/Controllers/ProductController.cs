using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ProductModel>> SearchProduct()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductModel> SearchById(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductModel> CreateProduct(ProductModel productModel)
        {
            if (string.IsNullOrEmpty(productModel.Name) || productModel.Name.Length < 3)
            {
                return BadRequest();
            }

            _context.Products.Add(productModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(SearchById), new { id = productModel.Id}, productModel);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductModel> EditProduct(ProductModel productModel, int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productModel.Name;
            product.Description = productModel.Description;
            product.Price = productModel.Price;

            _context.Products.Update(product);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductModel> DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

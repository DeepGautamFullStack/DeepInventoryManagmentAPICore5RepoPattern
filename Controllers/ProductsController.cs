using DeepInventoryManagmentAPICoreRepoPattern.Models;
using DeepInventoryManagmentAPICoreRepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeepInventoryManagmentAPICoreRepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly RepoPatternContext _context;

        private readonly IRepository<Products, int> _productRepository;

        public ProductsController(IRepository<Products, int> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Products>> GetProducts()
        {
            //var prod= _context.Products.ToListAsync();
            var prod1 = _productRepository.GetAll();
            return await prod1;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _productRepository.GetById(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            await _productRepository.Update(products);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            await _productRepository.Insert(products);

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var products = await _productRepository.GetById(id);
            if (products == null)
            {
                return NotFound();
            }

            await _productRepository.Delete(id);

            return NoContent();
        }

        private bool ProductsExists(int id)
        {
            var prod = _productRepository.GetById(id);
            if(prod!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using DeepInventoryManagmentAPICoreRepoPattern.Models;
using DeepInventoryManagmentAPICoreRepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeepInventoryManagmentAPICoreRepoPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly IRepository<Customer, int> _customerRepository;

        public CustomersController(IRepository<Customer, int> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            var cust = _customerRepository.GetAll();
            return await cust;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _customerRepository.Update(customer);

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            await _customerRepository.Insert(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var products = await _customerRepository.GetById(id);
            if (products == null)
            {
                return NotFound();
            }

            await _customerRepository.Delete(id);

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            var cust = _customerRepository.GetById(id);
            if (cust != null)
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

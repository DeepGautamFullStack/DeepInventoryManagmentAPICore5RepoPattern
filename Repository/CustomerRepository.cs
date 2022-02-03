using DeepInventoryManagmentAPICoreRepoPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepInventoryManagmentAPICoreRepoPattern.Repository
{
    public class CustomerRepository:IRepository<Customer,int>
    {
        private readonly RepoPatternContext _context;
        public CustomerRepository(RepoPatternContext context) => this._context = context;

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetById(int Id)
        {
            return await _context.Customer.FindAsync(Id);
        }

        public async Task<Customer> Insert(Customer entity)
        {
            await _context.Customer.AddAsync(entity);
            return entity;
        }
        public async Task Delete(int Id)
        {
            var prod = await _context.Customer.FirstOrDefaultAsync(p => p.Id == Id);
            if (prod != null)
            {
                _context.Remove(prod);
            }
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();

        }
    }
}

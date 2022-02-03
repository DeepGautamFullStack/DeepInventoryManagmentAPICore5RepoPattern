using DeepInventoryManagmentAPICoreRepoPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepInventoryManagmentAPICoreRepoPattern.Repository
{
    public class ProductRepository : IRepository<Products, int>
    {
        private readonly RepoPatternContext _context;
        public ProductRepository(RepoPatternContext context) => this._context = context;

        public async Task<IEnumerable<Products>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetById(int Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<Products> Insert(Products entity)
        {
            await _context.Products.AddAsync(entity);
            return entity;
        }
        public async Task Delete(int Id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
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

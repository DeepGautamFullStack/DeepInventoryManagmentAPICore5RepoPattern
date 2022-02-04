using DeepInventoryManagmentAPICoreRepoPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
          var result=  await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Products> Update(Products entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task Delete(int Id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (prod != null)
            {
                _context.Remove(prod);
              //await  _context.SaveChangesAsync();
            }
        }

    }
    }


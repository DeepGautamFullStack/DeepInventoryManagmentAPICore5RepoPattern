using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeepInventoryManagmentAPICoreRepoPattern.Models;

    public class RepoPatternContext : DbContext
    {
        public RepoPatternContext (DbContextOptions<RepoPatternContext> options)
            : base(options)
        {
        }

        public DbSet<DeepInventoryManagmentAPICoreRepoPattern.Models.Products> Products { get; set; }

        public DbSet<DeepInventoryManagmentAPICoreRepoPattern.Models.Customer> Customer { get; set; }
    }

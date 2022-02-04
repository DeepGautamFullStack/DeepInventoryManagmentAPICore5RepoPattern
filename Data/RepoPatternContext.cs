using Microsoft.EntityFrameworkCore;

public class RepoPatternContext : DbContext
    {
        public RepoPatternContext (DbContextOptions<RepoPatternContext> options)
            : base(options)
        {
        }

        public DbSet<DeepInventoryManagmentAPICoreRepoPattern.Models.Products> Products { get; set; }

        public DbSet<DeepInventoryManagmentAPICoreRepoPattern.Models.Customer> Customer { get; set; }
    }

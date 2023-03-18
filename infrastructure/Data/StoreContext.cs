using System.Reflection;
using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace infrastructure.Data
{
    public class StoreContext : DbContext
    {     
        // public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        // {

        // }
        
        protected readonly IConfiguration _configuration;

        public StoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("LoginConnection"));
        }
        public DbSet<Product> Products { get; set;} 
        public DbSet<ProductBrand> ProductBrands { get; set;} 

        public DbSet<ProductType> ProductTypes { get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
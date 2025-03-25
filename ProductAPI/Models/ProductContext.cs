using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public class ProductContext : DbContext
    {
        public String DatabasePath { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            var lad = Environment.SpecialFolder.LocalApplicationData;
            var folder = Environment.GetFolderPath(lad);
            DatabasePath = System.IO.Path.Join(folder, "Products.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
        }
        public DbSet<Product> Products { get; set; } = null!;
    }
}

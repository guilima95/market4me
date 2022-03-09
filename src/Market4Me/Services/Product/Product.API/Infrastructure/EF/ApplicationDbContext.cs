using Microsoft.EntityFrameworkCore;
using Product.API.Model;

namespace Product.API.Infrastructure.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ProductItem> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductItem>().HasData(new ProductItem
            {
                Id = Guid.NewGuid(),
                Name = "Refrigerante",
                Price = 15,
                Description = "Refrigerante faz mal, mas é gostoso.",
                ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/14.jpg",
                CategoryName = "Bebidas"
            });

        }
    }
}

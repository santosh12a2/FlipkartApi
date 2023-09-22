using FlipkartApi.Entites;
using FlipkartApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlipkartApi.Providers
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p=>p.Name).IsRequired().HasColumnType("varchar(100)");
            modelBuilder.Entity<Product>().Property(p=>p.Description).IsRequired().HasColumnType("varchar(200)");
            modelBuilder.Entity<Product>().Property(p=>p.Price).IsRequired().HasColumnType("decimal");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
        public void SaveData()
        {
            base.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;

namespace Shop.Database
{
   public class ApplicationDbContext : IdentityDbContext
   {
      public ApplicationDbContext(DbContextOptions options)
         : base(options) { }      

      public DbSet<Product> Products { get; set; }
      public DbSet<Stock> Stocks { get; set; }
      public DbSet<Order> Orders { get; set; }
      public DbSet<OrderProduct> OrderProducts { get; set; }

      
      protected override void OnModelCreating(ModelBuilder builder)
      {
         base.OnModelCreating(builder);

         // Provides a primary key to OrderProduct table
         // It is conformed of two keys: ProductId and OrderId. It is a composite key
         builder.Entity<OrderProduct>()
            .HasKey(x => new { x.ProductId, x.OrderId });
      }

   }
}

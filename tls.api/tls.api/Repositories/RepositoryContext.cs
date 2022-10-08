using Microsoft.EntityFrameworkCore;
using tls.api.OrderProducts;
using tls.api.Orders;
using tls.api.ProductReferences;
using tls.api.Products;

namespace tls.api.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductReferenceConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<OrderProductEntity>()
                .HasKey(t => new { t.OrderId, t.ProductId });

            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);
        }

        public DbSet<OrderEntity>? Orders { get; set; }
        public DbSet<OrderProductEntity>? OrderProducts { get; set; }
        public DbSet<ProductReferenceEntity>? ProductReferences { get; set; }
        public DbSet<ProductEntity>? Products { get; set; }
    }
}

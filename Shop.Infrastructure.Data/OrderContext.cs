using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;

namespace Shop.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<Markdown> Markdowns { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Subsidiary> Subsidiaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.HasOne(p => p.Storage).WithMany(s => s.Personnels)
                    .HasForeignKey(p => p.StorageId);
                entity.HasOne(p => p.Subsidiary).WithMany(s => s.Personnels)
                    .HasForeignKey(p => p.SubsidiaryId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.Rent).WithOne(r => r.Product)
                .HasForeignKey<Product>(p => p.RentId);
            });
        }
    }
}
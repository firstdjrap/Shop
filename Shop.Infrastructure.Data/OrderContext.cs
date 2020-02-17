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

        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Markdown> Markdowns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(p => p.Storage).WithMany(s => s.Employees)
                    .HasForeignKey(p => p.StorageId);
                entity.HasOne(p => p.BranchOffice).WithMany(s => s.Employees)
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
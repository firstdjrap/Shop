using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;

namespace Shop.Infrastructure.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
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
            modelBuilder.Entity<BranchOffice>(entity =>
            {
                entity.HasOne(b => b.Responsible).WithOne(e => e.BranchOffice)
                    .HasForeignKey<BranchOffice>(b => b.ResponsibleId);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasOne(c => c.DiscountCard).WithOne(d => d.Client)
                    .HasForeignKey<Client>(c => c.DiscountCardId);
            });

            modelBuilder.Entity<DiscountCard>(entity =>
            {
                entity.HasOne(d => d.Client).WithOne(c => c.DiscountCard)
                    .HasForeignKey<DiscountCard>(d => d.ClientId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(e => e.BranchOffice).WithOne(b => b.Responsible)
                    .HasForeignKey<Employee>(e => e.BranchOfficeId);
                entity.HasOne(e => e.Storage).WithOne(s => s.Responsible)
                    .HasForeignKey<Employee>(e => e.StorageId);
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(op => new { op.OrderId, op.ProductId });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.Rent).WithOne(r => r.Product)
                    .HasForeignKey<Product>(p => p.RentId)
                    .OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasOne(r => r.Product).WithOne(p => p.Rent)
                    .HasForeignKey<Rent>(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasOne(s => s.Responsible).WithOne(e => e.Storage)
                    .HasForeignKey<Storage>(s => s.ResponsibleId);
            });
        }
    }
}
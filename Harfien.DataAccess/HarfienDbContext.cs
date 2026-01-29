using Harfien.Domain.Entites;
using Harfien.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Harfien.DataAccess
{
    public class HarfienDbContext : IdentityDbContext<ApplicationUser>
    {
        public HarfienDbContext(DbContextOptions<HarfienDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Craftsman> Craftsmen { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ربط Client بالـ User
            builder.Entity<Client>()
                   .HasOne(c => c.User)
                   .WithOne()
                   .HasForeignKey<Client>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ربط Craftsman بالـ User
            builder.Entity<Craftsman>()
                   .HasOne(c => c.User)
                   .WithOne()
                   .HasForeignKey<Craftsman>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ربط Order بالـ Payment
            builder.Entity<Order>()
                   .HasOne(o => o.Payment)
                   .WithOne(p => p.Order)
                   .HasForeignKey<Payment>(p => p.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // مثال: لو عندك Service مرتبط بـ ServiceCategory
            builder.Entity<Service>()
                   .HasOne(s => s.ServiceCategory)
                   .WithMany(c => c.Services)
                   .HasForeignKey(s => s.ServiceCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


using Harfien.Domain.Entites;
using Harfien.Domain.Entities; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Harfien.DataAccess
{

    
        public class HarfienDbContext : IdentityDbContext<ApplicationUser>
        {
            public HarfienDbContext(DbContextOptions<HarfienDbContext> options)
                : base(options)
            {
            }

        #region   DbSets
        public DbSet<Service> Services { get; set; } = null!;
            public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
            public DbSet<Client> Clients { get; set; } = null!;
            public DbSet<Craftsman> Craftsmen { get; set; } = null!;
            public DbSet<Order> Orders { get; set; } = null!;
            public DbSet<Payment> Payments { get; set; } = null!;
            public DbSet<City> Cities { get; set; } = null!;
            public DbSet<Area> Areas { get; set; } = null!;
            public DbSet<Complaint> Complaints { get; set; } = null!;
            public DbSet<Review> Reviews { get; set; } = null!;

        #endregion
        

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

                // ربط Service بالـ ServiceCategory
                builder.Entity<Service>()
                       .HasOne(s => s.ServiceCategory)
                       .WithMany(c => c.Services)
                       .HasForeignKey(s => s.ServiceCategoryId)
                       .OnDelete(DeleteBehavior.Cascade);
                builder.Entity<Wallet>()
                    .HasOne(w => w.User)
                    .WithOne(u => u.Wallet)
                    .HasForeignKey<Wallet>(w => w.UserId);
               builder.Entity<Notification>()
                    .HasOne(n => n.ApplicationUsers)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId);
               builder.Entity<ChatMessage>()
                  .HasOne(m => m.Sender)
                  .WithMany(u => u.SentMessages)
                  .HasForeignKey(m => m.SenderId);

             
        }
    }
    }



using Harfien.Domain.Entites;
using Harfien.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

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
                       .OnDelete(DeleteBehavior.NoAction);

                // ربط Craftsman بالـ User
                builder.Entity<Craftsman>()
                       .HasOne(c => c.User)
                       .WithOne()
                       .HasForeignKey<Craftsman>(c => c.UserId)
                       .OnDelete(DeleteBehavior.NoAction);

                // ربط Order بالـ Payment
                builder.Entity<Order>()
                       .HasOne(o => o.Payment)
                       .WithOne(p => p.Order)
                       .HasForeignKey<Payment>(p => p.OrderId)
                       .OnDelete(DeleteBehavior.NoAction);

                // ربط Service بالـ ServiceCategory
                builder.Entity<Service>()
                       .HasOne(s => s.ServiceCategory)
                       .WithMany(c => c.Services)
                       .HasForeignKey(s => s.ServiceCategoryId)
                       .OnDelete(DeleteBehavior.NoAction);
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



            //SeedRoles
            builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole { Id = "2", Name = "Carftsman", NormalizedName = "CRAFTSMAN" },
               new IdentityRole { Id = "3", Name = "Client", NormalizedName = "CLIENT" }

               );

            //Seed Admin Data
            var hasher = new PasswordHasher<ApplicationUser>();



            var adminUser = new ApplicationUser
            {
                Id = "ADMIN_ID",
                UserName = "Admin@gamil.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                Fullname = "Nourhan Shaban",
                Address = "Cairo",
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                AreaId = null 
            };



            //Make HashPassword For Admin Account
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Nourhanshaban"); 

            builder.Entity<ApplicationUser>().HasData(adminUser);

            //Assign Role To Admin
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "ADMIN_ID",
                }
                );
        }
    }
    }




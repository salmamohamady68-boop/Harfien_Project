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

        public DbSet<ChatMessage> ChatMessage { get; set; } = null!;

        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(HarfienDbContext).Assembly);

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

            builder.Entity<Order>()
           .HasOne(o => o.Client)
           .WithMany(c => c.Orders)
           .HasForeignKey(o => o.ClientId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasOne(o => o.Craftsman)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CraftsmanId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                .HasOne(o => o.Service)
                .WithMany(s => s.Orders) // عندك ICollection<Order> بالفعل
                .HasForeignKey(o => o.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Order>()
                // ربط Order بالـ Payment
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Order>()
                // تحديد الـ decimal precision للـ Amount
                .Property(o => o.Amount)
                .HasPrecision(18, 2);  // أو HasColumnType("decimal(18,2)")

            builder.Entity<ChatMessage>()
                 .HasOne(m => m.Sender)
                .WithMany()
             .HasForeignKey(m => m.SenderId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ChatMessage>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            //// ربط Order بالـ Payment
            //builder.Entity<Order>()
            //       .HasOne(o => o.Payment)
            //       .WithOne(p => p.Order)
            //       .HasForeignKey<Payment>(p => p.OrderId);




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

            builder.Entity<Service>()
              .HasOne(s => s.Craftsman)
              .WithMany(c => c.CraftsmanServices)
              .HasForeignKey(s => s.CraftsmanId)
              .OnDelete(DeleteBehavior.NoAction);

            var fixedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
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
                FullName = "Admin",
                Address = "Cairo",
                CreatedAt = fixedDate,
                IsActive = true,
                AreaId = null
            };



            //Make HashPassword For Admin Account
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123456");

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



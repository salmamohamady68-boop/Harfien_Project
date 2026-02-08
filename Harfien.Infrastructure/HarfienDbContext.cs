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
                CreatedAt = DateTime.UtcNow,
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
                builder.Entity<City>().HasData(
                    new City { Id = 1, Name = "Cairo" },
                    new City { Id = 2, Name = "Giza" },
                    new City { Id = 3, Name = "Alexanderia" },
                    new City { Id = 4, Name = "Aswan" }
                    //,
                    //new City { Id = 5, Name = "Riyadh" } //sample for another country, does it need country table?
                    );
                builder.Entity<Area>().HasData(
                    new Area { Id = 1, CityId = 1, Name = "Maadi" },
                    new Area { Id = 2, CityId = 1, Name = "Helwan" },
                    new Area { Id = 3, CityId = 1, Name = "Ramses" },
                    new Area { Id = 4, CityId = 2, Name = "El Omarania" },
                    new Area { Id = 5, CityId = 3, Name = "Naga Elarab" }
                    //,
                    //new Area { Id = 6, CityId = 5, Name ="Olaya" }
                    );


        }
    }
    }




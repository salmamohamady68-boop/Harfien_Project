using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harfien.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Harfien.DataAccess.Context
{
    internal class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>  options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>()
                       .HasOne(c => c.User)
                       .WithOne()
                       .HasForeignKey<Client>(c => c.UserId);

            builder.Entity<Craftsman>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<Craftsman>(c => c.UserId);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Craftsman> Craftsmen { get; set; }
    }
}

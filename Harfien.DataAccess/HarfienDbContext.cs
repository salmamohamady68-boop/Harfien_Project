using Harfien.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Harfien.DataAccess
{
    public class HarfienDbContext : IdentityDbContext<User>
    {
        public HarfienDbContext(DbContextOptions<HarfienDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }

}


using Harfien.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                    new City { Id = 1, Name = "Cairo" },
                    new City { Id = 2, Name = "Giza" },
                    new City { Id = 3, Name = "Alexanderia" },
                    new City { Id = 4, Name = "Aswan" }
                    //,
                    //new City { Id = 5, Name = "Riyadh" } //sample for another country, does it need country table?
                    );
        }
    }
}

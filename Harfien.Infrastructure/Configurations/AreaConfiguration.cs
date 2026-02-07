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
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasData(
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

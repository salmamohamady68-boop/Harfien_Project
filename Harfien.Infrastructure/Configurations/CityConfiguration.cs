using Harfien.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harfien.Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            var fixedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            builder.HasData(
                    new City { Id = 1, Name = "القاهرة", CreatedAt = fixedDate },
                    new City { Id = 2, Name = "الجيزة", CreatedAt = fixedDate },
                    new City { Id = 3, Name = "الإسكندرية", CreatedAt = fixedDate },
                    new City { Id = 4, Name = "الدقهلية", CreatedAt = fixedDate },
                    new City { Id = 5, Name = "الشرقية", CreatedAt = fixedDate },
                    new City { Id = 6, Name = "القليوبية", CreatedAt = fixedDate },
                    new City { Id = 7, Name = "المنوفية", CreatedAt = fixedDate },
                    new City { Id = 8, Name = "البحيرة", CreatedAt = fixedDate },
                    new City { Id = 9, Name = "الغربية", CreatedAt = fixedDate },
                    new City { Id = 10, Name = "كفر الشيخ", CreatedAt = fixedDate },
                    new City { Id = 11, Name = "دمياط", CreatedAt = fixedDate },
                    new City { Id = 12, Name = "الإسماعيلية", CreatedAt = fixedDate },
                    new City { Id = 13, Name = "السويس", CreatedAt = fixedDate },
                    new City { Id = 14, Name = "بورسعيد", CreatedAt = fixedDate },
                    new City { Id = 15, Name = "شمال سيناء", CreatedAt = fixedDate },
                    new City { Id = 16, Name = "جنوب سيناء", CreatedAt = fixedDate },
                    new City { Id = 17, Name = "البحر الأحمر", CreatedAt = fixedDate },
                    new City { Id = 18, Name = "الوادي الجديد", CreatedAt = fixedDate },
                    new City { Id = 19, Name = "مطروح", CreatedAt = fixedDate },
                    new City { Id = 20, Name = "بني سويف", CreatedAt = fixedDate },
                    new City { Id = 21, Name = "الفيوم", CreatedAt = fixedDate },
                    new City { Id = 22, Name = "المنيا", CreatedAt = fixedDate },
                    new City { Id = 23, Name = "أسيوط", CreatedAt = fixedDate },
                    new City { Id = 24, Name = "سوهاج", CreatedAt = fixedDate },
                    new City { Id = 25, Name = "قنا", CreatedAt = fixedDate },
                    new City { Id = 26, Name = "الأقصر", CreatedAt = fixedDate },
                    new City { Id = 27, Name = "أسوان", CreatedAt = fixedDate }
                    );
        }
    }
}

using Harfien.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harfien.Infrastructure.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            var fixedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            builder.HasData(
                // القاهرة (1)
                new Area { Id = 1, CityId = 1, Name = "المعادي", CreatedAt = fixedDate },
                new Area { Id = 2, CityId = 1, Name = "حلوان", CreatedAt = fixedDate },
                new Area { Id = 3, CityId = 1, Name = "الزمالك", CreatedAt = fixedDate },
                new Area { Id = 4, CityId = 1, Name = "مصر الجديدة", CreatedAt = fixedDate },
                new Area { Id = 5, CityId = 1, Name = "النزهة", CreatedAt = fixedDate },
                new Area { Id = 6, CityId = 1, Name = "مدينة نصر", CreatedAt = fixedDate },
                new Area { Id = 7, CityId = 1, Name = "التجمع الخامس", CreatedAt = fixedDate },
                new Area { Id = 8, CityId = 1, Name = "الشروق", CreatedAt = fixedDate },

                // الجيزة (2)
                new Area { Id = 9, CityId = 2, Name = "العمرانية", CreatedAt = fixedDate },
                new Area { Id = 10, CityId = 2, Name = "الهرم", CreatedAt = fixedDate },
                new Area { Id = 11, CityId = 2, Name = "الدقي", CreatedAt = fixedDate },
                new Area { Id = 12, CityId = 2, Name = "الشيخ زايد", CreatedAt = fixedDate },
                new Area { Id = 13, CityId = 2, Name = "6 أكتوبر", CreatedAt = fixedDate },

                // الإسكندرية (3)
                new Area { Id = 14, CityId = 3, Name = "سيدي جابر", CreatedAt = fixedDate },
                new Area { Id = 15, CityId = 3, Name = "محرم بك", CreatedAt = fixedDate },
                new Area { Id = 16, CityId = 3, Name = "برج العرب", CreatedAt = fixedDate },
                new Area { Id = 17, CityId = 3, Name = "الحضرة", CreatedAt = fixedDate },
                new Area { Id = 18, CityId = 3, Name = "الإبراهيمية", CreatedAt = fixedDate },

                // الدقهلية (4)
                new Area { Id = 19, CityId = 4, Name = "المنصورة", CreatedAt = fixedDate },
                new Area { Id = 20, CityId = 4, Name = "شربين", CreatedAt = fixedDate },
                new Area { Id = 21, CityId = 4, Name = "أجا", CreatedAt = fixedDate },
                new Area { Id = 22, CityId = 4, Name = "السنبلاوين", CreatedAt = fixedDate },
                new Area { Id = 23, CityId = 4, Name = "تمي الأمديد", CreatedAt = fixedDate },

                // الشرقية (5)
                new Area { Id = 24, CityId = 5, Name = "الزقازيق", CreatedAt = fixedDate },
                new Area { Id = 25, CityId = 5, Name = "بلبيس", CreatedAt = fixedDate },
                new Area { Id = 26, CityId = 5, Name = "كفر صقر", CreatedAt = fixedDate },
                new Area { Id = 27, CityId = 5, Name = "الحسينية", CreatedAt = fixedDate },
                new Area { Id = 28, CityId = 5, Name = "10 رمضان", CreatedAt = fixedDate },

                // القليوبية (6)
                new Area { Id = 29, CityId = 6, Name = "بنها", CreatedAt = fixedDate },
                new Area { Id = 30, CityId = 6, Name = "الخصوص", CreatedAt = fixedDate },
                new Area { Id = 31, CityId = 6, Name = "شبرا الخيمة", CreatedAt = fixedDate },
                new Area { Id = 32, CityId = 6, Name = "القناطر الخيرية", CreatedAt = fixedDate },
                new Area { Id = 33, CityId = 6, Name = "طوخ", CreatedAt = fixedDate },

                // المنوفية (7)
                new Area { Id = 34, CityId = 7, Name = "شبين الكوم", CreatedAt = fixedDate },
                new Area { Id = 35, CityId = 7, Name = "قويسنا", CreatedAt = fixedDate },
                new Area { Id = 36, CityId = 7, Name = "أشمون", CreatedAt = fixedDate },
                new Area { Id = 37, CityId = 7, Name = "السادات", CreatedAt = fixedDate },
                new Area { Id = 38, CityId = 7, Name = "الباجور", CreatedAt = fixedDate },

                // البحيرة (8)
                new Area { Id = 39, CityId = 8, Name = "دمنهور", CreatedAt = fixedDate },
                new Area { Id = 40, CityId = 8, Name = "رشيد", CreatedAt = fixedDate },
                new Area { Id = 41, CityId = 8, Name = "إيتاي البارود", CreatedAt = fixedDate },
                new Area { Id = 42, CityId = 8, Name = "كفر الدوار", CreatedAt = fixedDate },
                new Area { Id = 43, CityId = 8, Name = "الرحمانية", CreatedAt = fixedDate },

                // الغربية (9)
                new Area { Id = 44, CityId = 9, Name = "طنطا", CreatedAt = fixedDate },
                new Area { Id = 45, CityId = 9, Name = "سمنود", CreatedAt = fixedDate },
                new Area { Id = 46, CityId = 9, Name = "زفتى", CreatedAt = fixedDate },
                new Area { Id = 47, CityId = 9, Name = "المحلة الكبرى", CreatedAt = fixedDate },
                new Area { Id = 48, CityId = 9, Name = "كفر الزيات", CreatedAt = fixedDate },

                // كفر الشيخ (10)
                new Area { Id = 49, CityId = 10, Name = "بيلا", CreatedAt = fixedDate },
                new Area { Id = 50, CityId = 10, Name = "الحامول", CreatedAt = fixedDate },
                new Area { Id = 51, CityId = 10, Name = "دسوق", CreatedAt = fixedDate },
                new Area { Id = 52, CityId = 10, Name = "سيدي سالم", CreatedAt = fixedDate },
                new Area { Id = 53, CityId = 10, Name = "فوه", CreatedAt = fixedDate },

                // دمياط (11)
                new Area { Id = 54, CityId = 11, Name = "دمياط الجديدة", CreatedAt = fixedDate },
                new Area { Id = 55, CityId = 11, Name = "فارسكور", CreatedAt = fixedDate },
                new Area { Id = 56, CityId = 11, Name = "رأس البر", CreatedAt = fixedDate },
                new Area { Id = 57, CityId = 11, Name = "كفر سعد", CreatedAt = fixedDate },
                new Area { Id = 58, CityId = 11, Name = "عزبة البرج", CreatedAt = fixedDate },

                // الإسماعيلية (12)
                new Area { Id = 59, CityId = 12, Name = "القنطرة شرق", CreatedAt = fixedDate },
                new Area { Id = 60, CityId = 12, Name = "القنطرة غرب", CreatedAt = fixedDate },
                new Area { Id = 61, CityId = 12, Name = "فايد", CreatedAt = fixedDate },
                new Area { Id = 62, CityId = 12, Name = "القصاصين", CreatedAt = fixedDate },
                new Area { Id = 63, CityId = 12, Name = "التل الكبير", CreatedAt = fixedDate },

                // السويس (13)
                new Area { Id = 64, CityId = 13, Name = "الجناين", CreatedAt = fixedDate },
                new Area { Id = 65, CityId = 13, Name = "عتاقة", CreatedAt = fixedDate },
                new Area { Id = 66, CityId = 13, Name = "الأربعين", CreatedAt = fixedDate },
                new Area { Id = 67, CityId = 13, Name = "حي فيصل", CreatedAt = fixedDate },

                // بورسعيد (14)
                new Area { Id = 68, CityId = 14, Name = "شرق بورسعيد", CreatedAt = fixedDate },
                new Area { Id = 69, CityId = 14, Name = "غرب بورسعيد", CreatedAt = fixedDate },
                new Area { Id = 70, CityId = 14, Name = "بورفؤاد", CreatedAt = fixedDate },
                new Area { Id = 71, CityId = 14, Name = "الضواحي", CreatedAt = fixedDate },

                // شمال سيناء (15)
                new Area { Id = 72, CityId = 15, Name = "العريش", CreatedAt = fixedDate },
                new Area { Id = 73, CityId = 15, Name = "رفح", CreatedAt = fixedDate },
                new Area { Id = 74, CityId = 15, Name = "الشيخ زويد", CreatedAt = fixedDate },
                new Area { Id = 75, CityId = 15, Name = "بئر العبد", CreatedAt = fixedDate },
                new Area { Id = 76, CityId = 15, Name = "نخل", CreatedAt = fixedDate },

                // جنوب سيناء (16)
                new Area { Id = 77, CityId = 16, Name = "شرم الشيخ", CreatedAt = fixedDate },
                new Area { Id = 78, CityId = 16, Name = "دهب", CreatedAt = fixedDate },
                new Area { Id = 79, CityId = 16, Name = "نويبع", CreatedAt = fixedDate },
                new Area { Id = 80, CityId = 16, Name = "طابا", CreatedAt = fixedDate },
                new Area { Id = 81, CityId = 16, Name = "سانت كاترين", CreatedAt = fixedDate },

                // البحر الأحمر (17)
                new Area { Id = 82, CityId = 17, Name = "الغردقة", CreatedAt = fixedDate },
                new Area { Id = 83, CityId = 17, Name = "سفاجا", CreatedAt = fixedDate },
                new Area { Id = 84, CityId = 17, Name = "القصير", CreatedAt = fixedDate },
                new Area { Id = 85, CityId = 17, Name = "مرسى علم", CreatedAt = fixedDate },
                new Area { Id = 86, CityId = 17, Name = "رأس غارب", CreatedAt = fixedDate },

                // الوادي الجديد (18)
                new Area { Id = 87, CityId = 18, Name = "الخارجة", CreatedAt = fixedDate },
                new Area { Id = 88, CityId = 18, Name = "الداخلة", CreatedAt = fixedDate },
                new Area { Id = 89, CityId = 18, Name = "باريس", CreatedAt = fixedDate },
                new Area { Id = 90, CityId = 18, Name = "الفرافرة", CreatedAt = fixedDate },

                // مطروح (19)
                new Area { Id = 91, CityId = 19, Name = "مرسى مطروح", CreatedAt = fixedDate },
                new Area { Id = 92, CityId = 19, Name = "السلوم", CreatedAt = fixedDate },
                new Area { Id = 93, CityId = 19, Name = "الضبعة", CreatedAt = fixedDate },
                new Area { Id = 94, CityId = 19, Name = "النجيلة", CreatedAt = fixedDate },

                // بني سويف (20)
                new Area { Id = 95, CityId = 20, Name = "ناصر", CreatedAt = fixedDate },
                new Area { Id = 96, CityId = 20, Name = "الفشن", CreatedAt = fixedDate },
                new Area { Id = 97, CityId = 20, Name = "سمسطا", CreatedAt = fixedDate },
                new Area { Id = 98, CityId = 20, Name = "إهناسيا", CreatedAt = fixedDate },
                new Area { Id = 99, CityId = 20, Name = "ببا", CreatedAt = fixedDate },

                // الفيوم (21)
                new Area { Id = 100, CityId = 21, Name = "يوسف الصديق", CreatedAt = fixedDate },
                new Area { Id = 101, CityId = 21, Name = "إطسا", CreatedAt = fixedDate },
                new Area { Id = 102, CityId = 21, Name = "سنورس", CreatedAt = fixedDate },
                new Area { Id = 103, CityId = 21, Name = "طامية", CreatedAt = fixedDate },
                new Area { Id = 104, CityId = 21, Name = "أبشواي", CreatedAt = fixedDate },

                // المنيا (22)
                new Area { Id = 105, CityId = 22, Name = "سمالوط", CreatedAt = fixedDate },
                new Area { Id = 106, CityId = 22, Name = "ملوي", CreatedAt = fixedDate },
                new Area { Id = 107, CityId = 22, Name = "بني مزار", CreatedAt = fixedDate },
                new Area { Id = 108, CityId = 22, Name = "أبو قرقاص", CreatedAt = fixedDate },
                new Area { Id = 109, CityId = 22, Name = "مغاغة", CreatedAt = fixedDate },

                // أسيوط (23)
                new Area { Id = 110, CityId = 23, Name = "ديروط", CreatedAt = fixedDate },
                new Area { Id = 111, CityId = 23, Name = "صدفا", CreatedAt = fixedDate },
                new Area { Id = 112, CityId = 23, Name = "الفتح", CreatedAt = fixedDate },
                new Area { Id = 113, CityId = 23, Name = "أبنوب", CreatedAt = fixedDate },
                new Area { Id = 114, CityId = 23, Name = "منفلوط", CreatedAt = fixedDate },

                // سوهاج (24)
                new Area { Id = 115, CityId = 24, Name = "أخميم", CreatedAt = fixedDate },
                new Area { Id = 116, CityId = 24, Name = "جرجا", CreatedAt = fixedDate },
                new Area { Id = 117, CityId = 24, Name = "البلينا", CreatedAt = fixedDate },
                new Area { Id = 118, CityId = 24, Name = "المراغة", CreatedAt = fixedDate },
                new Area { Id = 119, CityId = 24, Name = "دار السلام", CreatedAt = fixedDate },

                // قنا (25)
                new Area { Id = 120, CityId = 25, Name = "نجع حمادي", CreatedAt = fixedDate },
                new Area { Id = 121, CityId = 25, Name = "قفط", CreatedAt = fixedDate },
                new Area { Id = 122, CityId = 25, Name = "دندرة", CreatedAt = fixedDate },
                new Area { Id = 123, CityId = 25, Name = "أبو تشت", CreatedAt = fixedDate },
                new Area { Id = 124, CityId = 25, Name = "قنا الجديدة", CreatedAt = fixedDate },

                // الأقصر (26)
                new Area { Id = 125, CityId = 26, Name = "القرنة", CreatedAt = fixedDate },
                new Area { Id = 126, CityId = 26, Name = "مدينة الأقصر", CreatedAt = fixedDate },
                new Area { Id = 127, CityId = 26, Name = "الزينية", CreatedAt = fixedDate },
                new Area { Id = 128, CityId = 26, Name = "البياضية", CreatedAt = fixedDate },

                // أسوان (27)
                new Area { Id = 129, CityId = 27, Name = "دراو", CreatedAt = fixedDate },
                new Area { Id = 130, CityId = 27, Name = "كوم أمبو", CreatedAt = fixedDate },
                new Area { Id = 131, CityId = 27, Name = "إدفو", CreatedAt = fixedDate },
                new Area { Id = 132, CityId = 27, Name = "نصر النوبة", CreatedAt = fixedDate },
                new Area { Id = 133, CityId = 27, Name = "أسوان الجديدة", CreatedAt = fixedDate }
            );
        }
    }
}
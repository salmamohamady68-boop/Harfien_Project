using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Harfien.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReSeedCitiesAndAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "المعادي");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "حلوان");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "الزمالك");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CityId", "Name" },
                values: new object[] { 1, "مصر الجديدة" });

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CityId", "Name" },
                values: new object[] { 1, "النزهة" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 6, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مدينة نصر" },
                    { 7, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "التجمع الخامس" },
                    { 8, 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشروق" },
                    { 9, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "العمرانية" },
                    { 10, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الهرم" },
                    { 11, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الدقي" },
                    { 12, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشيخ زايد" },
                    { 13, 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "6 أكتوبر" },
                    { 14, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سيدي جابر" },
                    { 15, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "محرم بك" },
                    { 16, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "برج العرب" },
                    { 17, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الحضرة" },
                    { 18, 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الإبراهيمية" },
                    { 19, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المنصورة" },
                    { 20, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شربين" },
                    { 21, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أجا" },
                    { 22, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السنبلاوين" },
                    { 23, 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "تمي الأمديد" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42b16891-82be-4ad9-af88-a6d2a1ebcad5", "a974c4a5-3ecc-48d6-8b48-7a6147526d54" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "القاهرة");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "الجيزة");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "الإسكندرية");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "الدقهلية");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشرقية" },
                    { 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القليوبية" },
                    { 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المنوفية" },
                    { 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البحيرة" },
                    { 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الغربية" },
                    { 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر الشيخ" },
                    { 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دمياط" },
                    { 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الإسماعيلية" },
                    { 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السويس" },
                    { 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بورسعيد" },
                    { 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شمال سيناء" },
                    { 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "جنوب سيناء" },
                    { 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البحر الأحمر" },
                    { 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الوادي الجديد" },
                    { 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مطروح" },
                    { 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بني سويف" },
                    { 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفيوم" },
                    { 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المنيا" },
                    { 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسيوط" },
                    { 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سوهاج" },
                    { 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قنا" },
                    { 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الأقصر" },
                    { 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسوان" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CityId", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 24, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الزقازيق" },
                    { 25, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بلبيس" },
                    { 26, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر صقر" },
                    { 27, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الحسينية" },
                    { 28, 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "10 رمضان" },
                    { 29, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بنها" },
                    { 30, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الخصوص" },
                    { 31, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شبرا الخيمة" },
                    { 32, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القناطر الخيرية" },
                    { 33, 6, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طوخ" },
                    { 34, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شبين الكوم" },
                    { 35, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قويسنا" },
                    { 36, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أشمون" },
                    { 37, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السادات" },
                    { 38, 7, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الباجور" },
                    { 39, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دمنهور" },
                    { 40, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رشيد" },
                    { 41, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إيتاي البارود" },
                    { 42, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر الدوار" },
                    { 43, 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الرحمانية" },
                    { 44, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طنطا" },
                    { 45, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سمنود" },
                    { 46, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "زفتى" },
                    { 47, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المحلة الكبرى" },
                    { 48, 9, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر الزيات" },
                    { 49, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بيلا" },
                    { 50, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الحامول" },
                    { 51, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دسوق" },
                    { 52, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سيدي سالم" },
                    { 53, 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فوه" },
                    { 54, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دمياط الجديدة" },
                    { 55, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فارسكور" },
                    { 56, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رأس البر" },
                    { 57, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كفر سعد" },
                    { 58, 11, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "عزبة البرج" },
                    { 59, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القنطرة شرق" },
                    { 60, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القنطرة غرب" },
                    { 61, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "فايد" },
                    { 62, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القصاصين" },
                    { 63, 12, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "التل الكبير" },
                    { 64, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الجناين" },
                    { 65, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "عتاقة" },
                    { 66, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الأربعين" },
                    { 67, 13, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "حي فيصل" },
                    { 68, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شرق بورسعيد" },
                    { 69, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "غرب بورسعيد" },
                    { 70, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بورفؤاد" },
                    { 71, 14, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الضواحي" },
                    { 72, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "العريش" },
                    { 73, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رفح" },
                    { 74, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الشيخ زويد" },
                    { 75, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بئر العبد" },
                    { 76, 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نخل" },
                    { 77, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "شرم الشيخ" },
                    { 78, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دهب" },
                    { 79, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نويبع" },
                    { 80, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طابا" },
                    { 81, 16, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سانت كاترين" },
                    { 82, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الغردقة" },
                    { 83, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سفاجا" },
                    { 84, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القصير" },
                    { 85, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مرسى علم" },
                    { 86, 17, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "رأس غارب" },
                    { 87, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الخارجة" },
                    { 88, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الداخلة" },
                    { 89, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "باريس" },
                    { 90, 18, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفرافرة" },
                    { 91, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مرسى مطروح" },
                    { 92, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "السلوم" },
                    { 93, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الضبعة" },
                    { 94, 19, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "النجيلة" },
                    { 95, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ناصر" },
                    { 96, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفشن" },
                    { 97, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سمسطا" },
                    { 98, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إهناسيا" },
                    { 99, 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ببا" },
                    { 100, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "يوسف الصديق" },
                    { 101, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إطسا" },
                    { 102, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سنورس" },
                    { 103, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "طامية" },
                    { 104, 21, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبشواي" },
                    { 105, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "سمالوط" },
                    { 106, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ملوي" },
                    { 107, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "بني مزار" },
                    { 108, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبو قرقاص" },
                    { 109, 22, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مغاغة" },
                    { 110, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ديروط" },
                    { 111, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "صدفا" },
                    { 112, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الفتح" },
                    { 113, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبنوب" },
                    { 114, 23, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "منفلوط" },
                    { 115, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أخميم" },
                    { 116, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "جرجا" },
                    { 117, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البلينا" },
                    { 118, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "المراغة" },
                    { 119, 24, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دار السلام" },
                    { 120, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نجع حمادي" },
                    { 121, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قفط" },
                    { 122, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دندرة" },
                    { 123, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أبو تشت" },
                    { 124, 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "قنا الجديدة" },
                    { 125, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "القرنة" },
                    { 126, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "مدينة الأقصر" },
                    { 127, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "الزينية" },
                    { 128, 26, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "البياضية" },
                    { 129, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "دراو" },
                    { 130, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "كوم أمبو" },
                    { 131, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "إدفو" },
                    { 132, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "نصر النوبة" },
                    { 133, 27, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "أسوان الجديدة" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Maadi");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Helwan");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ramses");

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CityId", "Name" },
                values: new object[] { 2, "El Omarania" });

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CityId", "Name" },
                values: new object[] { 3, "Naga Elarab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN_ID",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "10b1abfa-1929-462d-8a4f-4d5eeb22c9bc", "cab06db5-3cf8-48de-84f4-06c4b64dc228" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Cairo");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Giza");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Alexanderia");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Aswan");
        }
    }
}

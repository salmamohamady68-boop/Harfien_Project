using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Harfien.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using AutoMapper;
using Harfien.Application.Mappings;
using Harfien.Application.Interfaces;
using Harfien.Application.Services;




namespace Harfien.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DbContext
            builder.Services.AddDbContext<HarfienDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            
            // Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HarfienDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            builder.Services.AddScoped<ISubscriptionPlanDetailsRepository, SubscriptionPlanDetailsRepository>();

            builder.Services.AddAutoMapper(
                             (sp, cfg) =>
                             {
                                 cfg.AllowNullCollections = true;

                             },
                             typeof(Application.AssemblyReference).Assembly
                         ); 
            
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

            // Controllers
            builder.Services.AddControllers();
            
            




            var app = builder.Build();

            
            app.UseHttpsRedirection();

            // 🔐 Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

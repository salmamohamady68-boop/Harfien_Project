using Harfien.Application.Autherization;
using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Harfien.Domain.Shared.Repositories;
using Harfien.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Services;
using Harfien.Domain.Shared.Repositories;
using Harfien.Infrastructure.Repositories;
using Harfien.Application.Interfaces;
using Harfien.Application.Services;
using Harfien.Application.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.OpenApi.Models;

using AutoMapper;
using System.Text;
using System.Reflection.Metadata;

namespace Harfien.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // =========================
            // DbContext
            // =========================
            builder.Services.AddDbContext<HarfienDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            // =========================
            // Identity
            // =========================
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
            })
            .AddEntityFrameworkStores<HarfienDbContext>()
            .AddDefaultTokenProviders();
            //jwt
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });

            //Authurization
            builder.Services.AddAuthorization();
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, DynamicPolicyProvider>();
            builder.Services.AddSingleton<IAuthorizationHandler, DynamicRoleHanlder>();

            //Services
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            builder.Services.AddScoped<ISubscriptionPlanDetailsRepository, SubscriptionPlanDetailsRepository>();
            //swagger
            builder.Services.AddSwaggerGen();

            //ForgetPassword
            builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(10));
            builder.Services.AddScoped<IEmailService, EmailSender>();
            builder.Services.AddMemoryCache();




            // =========================
            // Repositories & Services
            // =========================
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            builder.Services.AddScoped<ISubscriptionPlanDetailsRepository, SubscriptionPlanDetailsRepository>();
            builder.Services.AddScoped<ICraftsmanRepository, CraftsmanRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

            // =========================
            // AutoMapper
            // =========================
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
            }, typeof(AssemblyReference).Assembly);

            // =========================
            // JWT Authentication
            // =========================
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                    )
                };
            });

            // =========================
            // Controllers
            // =========================
            builder.Services.AddControllers();

            // =========================
            // Swagger
            // =========================
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {
                o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT like: Bearer {token}"
                });

                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // =========================
            // Build App
            // =========================
            var app = builder.Build();

            // =========================
            // Initialize Roles
            // =========================
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roles = { "CLIENT", "CRAFTSMAN", "ADMIN" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            // =========================
            // Middleware
            // =========================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // 🔐 Authentication & Authorization
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            await app.RunAsync();
        }
    }
}


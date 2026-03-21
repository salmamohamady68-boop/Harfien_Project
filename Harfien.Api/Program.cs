using E_Learning.Service.Contract;
using E_Learning.Service.Services;
using Harfien.Application;
using Harfien.Application.Autherization;
using Harfien.Application.Exceptions;
using Harfien.Application.Interfaces;
using Harfien.Application.Interfaces.payment_interfaces;
using Harfien.Application.Services;
using Harfien.DataAccess;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository;
using Harfien.Domain.Interface_Repository.Repositories;
using Harfien.Domain.Shared.Repositories;
using Harfien.Infrastructure.Repositories;
using Harfien.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

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
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            // =========================
            // Repositories
            // =========================
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ICraftsmanRepository, CraftsmanRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();
            builder.Services.AddScoped<ISubscriptionPlanDetailsRepository, SubscriptionPlanDetailsRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IAreaRepository, AreaRepository>();
            builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IMessageRepositry, MessageRepositry>();

            // =========================
            // Services
            // =========================
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IEmailService, EmailSender>();
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<ICraftsmanService, CraftsmanService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IWalletService, WalletService>();
            builder.Services.AddScoped<IWalletTransactionService, WalletTransactionService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IAreaService, AreaService>();
            builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IComplaintService, ComplaintService>();
            builder.Services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
            builder.Services.AddScoped<IChatService, ChatService>();
            builder.Services.AddScoped<IChatNotifier, ChatNotifier>();

            // SignalR
            builder.Services.AddSignalR();

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
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
                        var userId = context.Principal?.FindFirstValue(ClaimTypes.NameIdentifier);
                        if (userId == null) { context.Fail("Invalid token"); return; }

                        var user = await userManager.FindByIdAsync(userId);
                        if (user == null) { context.Fail("User not found"); return; }

                        var tokenSecurityStamp = context.Principal?.FindFirstValue("SecurityStamp");
                        var userSecurityStamp = await userManager.GetSecurityStampAsync(user);
                        if (tokenSecurityStamp != userSecurityStamp) { context.Fail("Token invalidated"); return; }
                    }
                };
            });

            // =========================
            // Authorization
            // =========================
            builder.Services.AddAuthorization();
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, DynamicPolicyProvider>();
            builder.Services.AddSingleton<IAuthorizationHandler, DynamicRoleHanlder>();

            // =========================
            // Misc
            // =========================
            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }, typeof(Application.AssemblyReference).Assembly);

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(10));

            // =========================
            // Controllers & Swagger
            // =========================
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT like: Bearer {token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // =========================
            // Middleware
            // =========================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerPathFeature?.Error;

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = exception switch
                    {
                        NotFoundException => 404,
                        BadRequestException => 400,
                        _ => 500
                    };
                    await context.Response.WriteAsJsonAsync(new { error = exception?.Message });
                });
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.MapHub<ChatHub>("/chatHub");
            app.MapHub<NotificationHub>("/notificationHub");

            await app.RunAsync();
        }
    }
}
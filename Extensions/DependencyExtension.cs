using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using StoreApplication.Migrations;

namespace StoreApplication.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies (this IServiceCollection services)
        {
            services.AddControllers ().AddNewtonsoftJson (options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver ();
            });
            services.AddEndpointsApiExplorer ();
            services.AddAutoMapper (AppDomain.CurrentDomain.GetAssemblies ());
            services.AddSwaggerGen (options =>
                options.SwaggerDoc ("v1", new OpenApiInfo { Title = "STORE API", Version = "V1" }));
            services.AddAuthentication ();
            services.AddCors (options => options.AddPolicy (name: "*", configurePolicy => configurePolicy
                .WithOrigins ("http://localhost:4200")
                .AllowAnyMethod ()
                .AllowAnyHeader ()));
            services.AddCookiePolicy (cookiePolicyOptions =>
            {
                cookiePolicyOptions.CheckConsentNeeded = context => true;
                cookiePolicyOptions.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddIdentity<IdentityUser, IdentityRole> (options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<AppDbContext> ()
                .AddDefaultTokenProviders ();
        }
    }
}

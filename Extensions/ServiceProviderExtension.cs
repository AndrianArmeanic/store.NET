using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StoreApplication.Models;
using StoreApplication.Repos.Order;
using StoreApplication.Repos.Product;
using StoreApplication.Repos.User;
using StoreApplication.Services;

namespace StoreApplication.Extensions
{
    public static class ServiceProviderExtension
    {
        public static void AddServiceProviders(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<UserModel>, BCryptPasswordHasher<UserModel>>();
            services.AddTransient<IProductRepo, ProductRepo> ();
            services.AddTransient<IOrderRepo, OrderRepo> ();
            services.AddTransient<IUserRepo, UserRepo> ();
        }
    }
}

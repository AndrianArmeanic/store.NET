using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreApplication.Models;

namespace StoreApplication.Migrations
{
    public class AppDbContext : IdentityDbContext
    {
        private DbSet<UserModel> Users { get; set; } = default!;

        private DbSet<ProductModel> Products { get; set; } = default!;

        private DbSet<OrderModel> Orders { get; set; } = default!;

        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            AppDbContext.CreateModelRelations(modelBuilder);
            AppDbContext.SeedEntities (modelBuilder);
        }

        private static void CreateModelRelations (ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OrderModel> ()
                .HasKey (order => order.Id)
                .HasName ("id");
            modelBuilder
                .Entity<ProductModel> ()
                .HasKey (product => product.Id)
                .HasName ("id");
            modelBuilder
                .Entity<UserModel> ()
                .HasKey (user => user.Id)
                .HasName ("id");
            
            modelBuilder
                .Entity<OrderModel> ()
                .HasOne (order => order.User)
                .WithMany ()
                .HasForeignKey (order => order.UserId)
                .OnDelete (DeleteBehavior.Cascade)
                .IsRequired ();

            modelBuilder
                .Entity<OrderModel> ()
                .HasOne (order => order.Product)
                .WithMany ()
                .HasForeignKey (order => order.ProductId)
                .OnDelete (DeleteBehavior.Cascade)
                .IsRequired ();
        }

        private static void SeedEntities (ModelBuilder modelBuilder)
        {
            ProductModel product1 = new()
            {
                Name = "Product_1",
                Description = "Some description about first product"
            };
            ProductModel product2 = new()
            {
                Name = "Product_2",
                Description = "Some description about second product"
            };
            modelBuilder.Entity<ProductModel> ().HasData (product1, product2);

            UserModel user1 = new()
            {
                UserName = "Username_1",
                Email = "username1@gmail.com",
                Password = "password"
            };
            UserModel user2 = new()
            {
                UserName = "Username_2",
                Email = "username2@gmail.com",
                Password = "password"
            };
            modelBuilder.Entity<UserModel> ().HasData (user1, user2);

            modelBuilder
                .Entity<OrderModel> ()
                .HasData (
                    new OrderModel () { ProductId = product1.Id, UserId = new Guid (user1.Id) },
                    new OrderModel () { ProductId = product1.Id, UserId = new Guid (user2.Id) }
                );
        }
    }
};

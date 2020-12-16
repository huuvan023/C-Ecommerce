using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Configuration;
using WebAPI.Data.Entities;
using WebAPI.Data.Extensions;

namespace WebAPI.Data.EF
{
    public class WebApiDbContext:IdentityDbContext<users,role,Guid>
    {
        public WebApiDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config

            modelBuilder.ApplyConfiguration(new productsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new usersConfiguration());
            modelBuilder.ApplyConfiguration(new productPhotosConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new productColorConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            //seeding
            modelBuilder.Seed();


        }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<productBrand> ProductBrands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<productColor> ProductColors { get; set; }
        public DbSet<productDetail> productDetails { get; set; }
        public DbSet<productPhotos> productPhotos { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<productSize> ProductSizes { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<productTypes> ProductTypes { get; set; }
        public DbSet<rating> ratings { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<vouchers> vouchers { get; set; }

        public DbSet<Slide> Slides { get; set; }




    }
}

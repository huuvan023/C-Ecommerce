using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;
using WebAPI.Data.Enums;

namespace WebAPI.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<productDetail>().HasData(
                new productDetail() { ProductId = 1,idProductDetail=1, LanguageId = "vi", ProductName="Ao nam",price=10,salePrice=10,detail="goood product",isSaling=false,dateAdded=new DateTime(2019,10,21)},
                new productDetail() { ProductId = 2,idProductDetail = 2, LanguageId = "vi", ProductName = "Ao nam" ,price = 20, salePrice = 10, detail = "goood product", isSaling = false, expiredSalingDate=new DateTime(2020,10,12), dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 3, idProductDetail = 3, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 4, idProductDetail = 4, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 5, idProductDetail = 5, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 6, idProductDetail = 6, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 7, idProductDetail = 7, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 8, idProductDetail = 8, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 9, idProductDetail = 9, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 10, idProductDetail = 10, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) },
                new productDetail() { ProductId = 11, idProductDetail = 11, LanguageId = "vi", ProductName = "Ao nam", price = 10, salePrice = 10, detail = "goood product", isSaling = false, dateAdded = new DateTime(2019, 10, 21) }

            );;
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false }
            );

            modelBuilder.Entity<productSize>().HasData(
                new productSize() { idSize = "L", sizeName = "L", LanguageId = "vi" },
                new productSize() { idSize = "M", sizeName = "M", LanguageId = "vi" },
                new productSize() { idSize="XL",sizeName="XL", LanguageId = "vi" },
                new productSize() { idSize="XLL",sizeName="XLL", LanguageId = "vi" }
            );
            modelBuilder.Entity<productBrand>().HasData(
                new productBrand() { idBrand="1",brandName="Logo",brandDetail="Logo",LanguageId="vi"},
                new productBrand() { idBrand = "2", brandName = "Company", brandDetail = "Company", LanguageId = "vi" }
            );
            modelBuilder.Entity<productColor>().HasData(
                new productColor() { idColor="Red",colorName="Red", LanguageId = "vi" },
                new productColor() { idColor = "While", colorName = "While", LanguageId = "vi" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { idCategory=1, IsShowOnHome = true, SortOrder = 1, },
                new Category() { idCategory = 2, IsShowOnHome = true, SortOrder = 2, },
                 new Category() { idCategory = 3, IsShowOnHome = true, SortOrder = 3, },
                new Category() { idCategory = 4, IsShowOnHome = true, SortOrder = 4, },
                 new Category() { idCategory = 5, IsShowOnHome = true, SortOrder = 5, },
                new Category() { idCategory = 6, IsShowOnHome = true, SortOrder = 6, }
            );
            modelBuilder.Entity<productTypes>().HasData(
                new productTypes() { idType="VIP",typeName="Cao cấp"},
                new productTypes() { idType = "NORMAL", typeName = "Bình Thường" }
            );

            modelBuilder.Entity<productPhotos>().HasData(
                new productPhotos() { Id=1,idProduct=1,ImagePath= "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg",Caption= "Thumbnail image",IsDefault=true,SortOrder=1,FileSize=53562,uploadedTime= new DateTime(2020, 10, 12) },
                new productPhotos() { Id=2,idProduct=2,ImagePath= "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg",Caption= "Thumbnail image",IsDefault=true,SortOrder=2,FileSize=53562,uploadedTime= new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 3, idProduct = 3, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 3, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 4, idProduct = 4, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 4, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 5, idProduct = 5, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 5, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 6, idProduct = 6, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 6, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 7, idProduct = 7, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 7, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 8, idProduct = 8, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 7, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 9, idProduct = 9, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 7, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 10, idProduct = 10, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 7, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) },
                new productPhotos() { Id = 11, idProduct = 11, ImagePath = "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", Caption = "Thumbnail image", IsDefault = true, SortOrder = 7, FileSize = 53562, uploadedTime = new DateTime(2020, 10, 12) }
          
                );
            modelBuilder.Entity<products>().HasData(
                new products() { ProductId = 1 ,idSize = "L", idBrand = "1", idColor = "While",  idType = "VIP" },
                new products() { ProductId = 2, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 3, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 4, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 5, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 6, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 7, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 8, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 9, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 10, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" },
                new products() { ProductId = 11, idSize = "L", idBrand = "1", idColor = "While", idType = "VIP" }

            );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, idCategory = 1 },
                 new ProductInCategory() { ProductId = 2, idCategory = 1 },
                  new ProductInCategory() { ProductId = 3, idCategory = 1 },
                   new ProductInCategory() { ProductId = 4, idCategory = 1 },
                   new ProductInCategory() { ProductId = 5, idCategory = 1 },
                   new ProductInCategory() { ProductId = 6, idCategory = 1 },
                   new ProductInCategory() { ProductId = 7, idCategory = 1 },
                   new ProductInCategory() { ProductId = 8, idCategory = 1 },
                   new ProductInCategory() { ProductId = 9, idCategory = 1 },
                   new ProductInCategory() { ProductId = 10, idCategory = 1 },
                   new ProductInCategory() { ProductId =11, idCategory = 1 }


                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                 new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                 new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                 new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" },
                 new CategoryTranslation() { Id = 5, CategoryId = 3, Name = "Máy ảnh", LanguageId = "vi", SeoAlias = "may-anh", SeoDescription = "may anh", SeoTitle = "may anh" },
                 new CategoryTranslation() { Id = 6, CategoryId = 4, Name = "Giày", LanguageId = "vi", SeoAlias = "giay", SeoDescription = "giay nam", SeoTitle = "giay nam" },
                 new CategoryTranslation() { Id = 7, CategoryId = 5, Name = "Quần nam", LanguageId = "vi", SeoAlias = "quan-nam", SeoDescription = "quan-nam", SeoTitle = "quan-nam" }
                   );

            

            // any guid

            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<role>().HasData(new role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<users>();
            modelBuilder.Entity<users>().HasData(new users
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nhattruongtp2000@gmail.com",
                NormalizedEmail = "nhattruongtp2000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                birthday=new DateTime(2020,10,12),
                firstName = "Nguyen",
                lastName = "Truong",
                lastLogin=new DateTime(2020,11,13)
 
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = true },
              new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = true },
              new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = true },
              new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = true },
              new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = true },
              new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = true }
              );

        }
    }
}

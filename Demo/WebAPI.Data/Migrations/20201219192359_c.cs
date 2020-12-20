using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "ProductId", "idCategory" },
                values: new object[] { 8, 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "6bad0467-cb6e-4859-a9b6-952a3855185c");

            migrationBuilder.InsertData(
                table: "productDetails",
                columns: new[] { "idProductDetail", "CategoryidCategory", "LanguageId", "ProductId", "ProductName", "dateAdded", "detail", "expiredSalingDate", "isSaling", "price", "salePrice" },
                values: new object[] { 8, null, "vi", 8, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" });

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "SortOrder",
                value: 7);

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "IsFeatured", "ViewCount", "idBrand", "idColor", "idSize", "idType" },
                values: new object[,]
                {
                    { 9, null, 0, "1", "While", "L", "VIP" },
                    { 10, null, 0, "1", "While", "L", "VIP" },
                    { 11, null, 0, "1", "While", "L", "VIP" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b310241e-46ef-4319-a026-680c703d81f8", "AQAAAAEAACcQAAAAEDb5+2IEpdNULojnkwej4f/+GewwAiZxC2S/zJd9ypoyU9VvzQwxn+v2m/5NCTRI6g==" });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "ProductId", "idCategory" },
                values: new object[,]
                {
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 }
                });

            migrationBuilder.InsertData(
                table: "productDetails",
                columns: new[] { "idProductDetail", "CategoryidCategory", "LanguageId", "ProductId", "ProductName", "dateAdded", "detail", "expiredSalingDate", "isSaling", "price", "salePrice" },
                values: new object[,]
                {
                    { 9, null, "vi", 9, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" },
                    { 10, null, "vi", 10, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" },
                    { 11, null, "vi", 11, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" }
                });

            migrationBuilder.InsertData(
                table: "productPhotos",
                columns: new[] { "Id", "Caption", "FileSize", "ImagePath", "IsDefault", "SortOrder", "idProduct", "uploadedTime" },
                values: new object[,]
                {
                    { 9, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 7, 9, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 7, 10, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 7, 11, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "ProductId", "idCategory" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "ProductId", "idCategory" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "ProductId", "idCategory" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "ProductId", "idCategory" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "1c9e7121-c783-4fb9-8a47-44193c059702");

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "SortOrder",
                value: 8);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5ffd5d2-96c7-4435-be03-aa78d8a3fcbc", "AQAAAAEAACcQAAAAEItJDHzKvh5CAc1pEqk6acZyxI712+LJAUXCtUf6/yArQrROfbmpoEvPNs/E0AMIwQ==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "idBrand",
                keyValue: "1",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "idBrand",
                keyValue: "2",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "idColor",
                keyValue: "Red",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "idColor",
                keyValue: "While",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "L",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "M",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "XL",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "XLL",
                column: "LanguageId",
                value: "vi");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "1c9e7121-c783-4fb9-8a47-44193c059702");

            migrationBuilder.UpdateData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 1,
                column: "ProductName",
                value: "Ao nam");

            migrationBuilder.UpdateData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 2,
                column: "ProductName",
                value: "Ao nam");

            migrationBuilder.InsertData(
                table: "productDetails",
                columns: new[] { "idProductDetail", "CategoryidCategory", "LanguageId", "ProductId", "ProductName", "dateAdded", "detail", "expiredSalingDate", "isSaling", "price", "salePrice" },
                values: new object[,]
                {
                    { 6, null, "vi", 6, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" },
                    { 5, null, "vi", 5, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" },
                    { 4, null, "vi", 4, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" },
                    { 7, null, "vi", 7, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" },
                    { 3, null, "vi", 3, "Ao nam", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" }
                });

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 1,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 2,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 3,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 4,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 5,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 6,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "uploadedTime",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5ffd5d2-96c7-4435-be03-aa78d8a3fcbc", "AQAAAAEAACcQAAAAEItJDHzKvh5CAc1pEqk6acZyxI712+LJAUXCtUf6/yArQrROfbmpoEvPNs/E0AMIwQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "idBrand",
                keyValue: "1",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductBrands",
                keyColumn: "idBrand",
                keyValue: "2",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "idColor",
                keyValue: "Red",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "idColor",
                keyValue: "While",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "L",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "M",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "XL",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductSizes",
                keyColumn: "idSize",
                keyValue: "XLL",
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "fafef564-859f-40ff-a73d-1cddc389cbbe");

            migrationBuilder.UpdateData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 1,
                column: "ProductName",
                value: "Shoe");

            migrationBuilder.UpdateData(
                table: "productDetails",
                keyColumn: "idProductDetail",
                keyValue: 2,
                column: "ProductName",
                value: "Pro");

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 1,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 306, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 2,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 3,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 4,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 5,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 6,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "productPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "uploadedTime",
                value: new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a401b1c-6f45-4047-9111-b1495573a5e3", "AQAAAAEAACcQAAAAEGOobDexV7mGP5VeoW2qOwBLOu9h21zDB1LxRPICnAap3wjEoc9+6+KE0znC5xkfUA==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    idOrder = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false),
                    idVoucher = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.idOrder);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    lastName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    birthday = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    note = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    province = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    interestedIn = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    lastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "vouchers",
                columns: table => new
                {
                    idVoucher = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    isUse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vouchers", x => x.idVoucher);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsShowOnHome = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.idCategory);
                    table.ForeignKey(
                        name: "FK_Categories_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    idBrand = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    brandName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    brandDetail = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.idBrand);
                    table.ForeignKey(
                        name: "FK_ProductBrands_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    idColor = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    colorName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.idColor);
                    table.ForeignKey(
                        name: "FK_ProductColors_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    idSize = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    sizeName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.idSize);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    idType = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    typeName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.idType);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSize = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    idBrand = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    idColor = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    idType = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    ordersDetailsidOrder = table.Column<string>(type: "VARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_OrdersDetails_ordersDetailsidOrder",
                        column: x => x.ordersDetailsidOrder,
                        principalTable: "OrdersDetails",
                        principalColumn: "idOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_ProductBrands_idBrand",
                        column: x => x.idBrand,
                        principalTable: "ProductBrands",
                        principalColumn: "idBrand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_ProductColors_idColor",
                        column: x => x.idColor,
                        principalTable: "ProductColors",
                        principalColumn: "idColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_ProductSizes_idSize",
                        column: x => x.idSize,
                        principalTable: "ProductSizes",
                        principalColumn: "idSize",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_ProductTypes_idType",
                        column: x => x.idType,
                        principalTable: "ProductTypes",
                        principalColumn: "idType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SeoAlias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productsProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_products_productsProductId",
                        column: x => x.productsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ordersLists",
                columns: table => new
                {
                    idOrder = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ordersLists_OrdersDetails_idOrder",
                        column: x => x.idOrder,
                        principalTable: "OrdersDetails",
                        principalColumn: "idOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersLists_products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersLists_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productDetails",
                columns: table => new
                {
                    idProductDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    price = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    salePrice = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    detail = table.Column<string>(type: "VARCHAR(2000)", nullable: false),
                    isSaling = table.Column<bool>(type: "bit", nullable: false),
                    expiredSalingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryidCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDetails", x => x.idProductDetail);
                    table.ForeignKey(
                        name: "FK_productDetails_Categories_CategoryidCategory",
                        column: x => x.CategoryidCategory,
                        principalTable: "Categories",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productDetails_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_productDetails_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCategories", x => new { x.idCategory, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Categories_idCategory",
                        column: x => x.idCategory,
                        principalTable: "Categories",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCategories_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProduct = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    uploadedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productPhotos_products_idProduct",
                        column: x => x.idProduct,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    rateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false),
                    idProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ratings_productDetails_idProduct",
                        column: x => x.idProduct,
                        principalTable: "productDetails",
                        principalColumn: "idProductDetail",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratings_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "idCategory", "IsShowOnHome", "LanguageId", "SortOrder" },
                values: new object[,]
                {
                    { 1, true, null, 1 },
                    { 2, true, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi", true, "Tiếng Việt" },
                    { "en", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "idBrand", "LanguageId", "brandDetail", "brandName" },
                values: new object[,]
                {
                    { "1", null, "Logo", "Logo" },
                    { "2", null, "Company", "Company" }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "idColor", "LanguageId", "colorName" },
                values: new object[,]
                {
                    { "ffffff", null, "While" },
                    { "Red", null, "Red" }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "idSize", "LanguageId", "sizeName" },
                values: new object[,]
                {
                    { "1", null, "L" },
                    { "2", null, "M" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "idType", "LanguageId", "typeName" },
                values: new object[,]
                {
                    { "1", null, "Cheap" },
                    { "2", null, "Expensive" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "7ad11c82-faf7-4a0d-a3d1-6d0f27641567", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "birthday", "firstName", "interestedIn", "lastLogin", "lastName", "note", "province" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "367521b9-5a3b-44cb-889d-742d789ce350", "nhattruongtp2000@gmail.com", true, false, null, "nhattruongtp2000@gmail.com", "admin", "AQAAAAEAACcQAAAAELtp3h+nmocrBw5gpBe2ShGuXnVdzDBKu4hULeO7Jbd3bJ/zXb/DNfMC5g6F+TySHw==", null, false, "", false, "admin", "2020-10-12 00:00:00", "Nguyen", null, new DateTime(2020, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Truong", null, null });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle", "productsProductId" },
                values: new object[,]
                {
                    { 1, 1, "vi", "Áo nam", "ao-nam", "Sản phẩm áo thời trang nam", "Sản phẩm áo thời trang nam", null },
                    { 3, 2, "vi", "Áo nữ", "ao-nu", "Sản phẩm áo thời trang nữ", "Sản phẩm áo thời trang women", null },
                    { 2, 1, "en", "Men Shirt", "men-shirt", "The shirt products for men", "The shirt products for men", null },
                    { 4, 2, "en", "Women Shirt", "women-shirt", "The shirt products for women", "The shirt products for women", null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "ViewCount", "idBrand", "idColor", "idSize", "idType", "ordersDetailsidOrder" },
                values: new object[,]
                {
                    { 1, 0, "1", "ffffff", "1", "1", null },
                    { 2, 0, "1", "ffffff", "1", "1", null }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "ProductId", "idCategory" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "productDetails",
                columns: new[] { "idProductDetail", "CategoryidCategory", "LanguageId", "ProductId", "ProductName", "dateAdded", "detail", "expiredSalingDate", "isSaling", "price", "salePrice" },
                values: new object[] { 1, null, "vi", 1, "Shoe", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "1000000", "1000000" });

            migrationBuilder.InsertData(
                table: "productDetails",
                columns: new[] { "idProductDetail", "CategoryidCategory", "LanguageId", "ProductId", "ProductName", "dateAdded", "detail", "expiredSalingDate", "isSaling", "price", "salePrice" },
                values: new object[] { 2, null, "vi", 2, "Pro", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "2000000", "1000000" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LanguageId",
                table: "Categories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_productsProductId",
                table: "CategoryTranslations",
                column: "productsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersLists_idOrder",
                table: "ordersLists",
                column: "idOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ordersLists_idProduct",
                table: "ordersLists",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ordersLists_idUser",
                table: "ordersLists",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrands_LanguageId",
                table: "ProductBrands",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_LanguageId",
                table: "ProductColors",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_productDetails_CategoryidCategory",
                table: "productDetails",
                column: "CategoryidCategory");

            migrationBuilder.CreateIndex(
                name: "IX_productDetails_LanguageId",
                table: "productDetails",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_productDetails_ProductId",
                table: "productDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_ProductId",
                table: "ProductInCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productPhotos_idProduct",
                table: "productPhotos",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_products_idBrand",
                table: "products",
                column: "idBrand");

            migrationBuilder.CreateIndex(
                name: "IX_products_idColor",
                table: "products",
                column: "idColor");

            migrationBuilder.CreateIndex(
                name: "IX_products_idSize",
                table: "products",
                column: "idSize");

            migrationBuilder.CreateIndex(
                name: "IX_products_idType",
                table: "products",
                column: "idType");

            migrationBuilder.CreateIndex(
                name: "IX_products_ordersDetailsidOrder",
                table: "products",
                column: "ordersDetailsidOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_LanguageId",
                table: "ProductSizes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_LanguageId",
                table: "ProductTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_idProduct",
                table: "ratings",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_idUser",
                table: "ratings",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "ordersLists");

            migrationBuilder.DropTable(
                name: "ProductInCategories");

            migrationBuilder.DropTable(
                name: "productPhotos");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "vouchers");

            migrationBuilder.DropTable(
                name: "productDetails");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}

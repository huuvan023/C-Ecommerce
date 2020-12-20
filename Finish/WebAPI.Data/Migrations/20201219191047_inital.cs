using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class inital : Migration
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
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
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
                    ParentId = table.Column<int>(type: "int", nullable: true),
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_users_usersId",
                        column: x => x.usersId,
                        principalTable: "users",
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
                    IsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
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
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productDetails",
                columns: table => new
                {
                    idProductDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    price = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    salePrice = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    detail = table.Column<string>(type: "NVARCHAR(2000)", nullable: false),
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
                columns: new[] { "idCategory", "IsShowOnHome", "LanguageId", "ParentId", "SortOrder" },
                values: new object[,]
                {
                    { 1, true, null, null, 1 },
                    { 2, true, null, null, 2 },
                    { 3, true, null, null, 3 },
                    { 4, true, null, null, 4 },
                    { 5, true, null, null, 5 },
                    { 6, true, null, null, 6 }
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
                    { "2", null, "Company", "Company" },
                    { "1", null, "Logo", "Logo" }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "idColor", "LanguageId", "colorName" },
                values: new object[,]
                {
                    { "While", null, "While" },
                    { "Red", null, "Red" }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "idSize", "LanguageId", "sizeName" },
                values: new object[,]
                {
                    { "L", null, "L" },
                    { "XLL", null, "XLL" },
                    { "M", null, "M" },
                    { "XL", null, "XL" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "idType", "LanguageId", "typeName" },
                values: new object[,]
                {
                    { "VIP", null, "Cao cấp" },
                    { "NORMAL", null, "Bình Thường" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "fafef564-859f-40ff-a73d-1cddc389cbbe", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/4.png", "Second Thumbnail label", 4, true, "#" },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/3.png", "Second Thumbnail label", 3, true, "#" },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/2.png", "Second Thumbnail label", 2, true, "#" },
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/1.png", "Second Thumbnail label", 1, true, "#" },
                    { 6, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/6.png", "Second Thumbnail label", 6, true, "#" },
                    { 5, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/5.png", "Second Thumbnail label", 5, true, "#" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "birthday", "firstName", "interestedIn", "lastLogin", "lastName", "note", "province" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "3a401b1c-6f45-4047-9111-b1495573a5e3", "nhattruongtp2000@gmail.com", true, false, null, "nhattruongtp2000@gmail.com", "admin", "AQAAAAEAACcQAAAAEGOobDexV7mGP5VeoW2qOwBLOu9h21zDB1LxRPICnAap3wjEoc9+6+KE0znC5xkfUA==", null, false, "", false, "admin", "2020-10-12 00:00:00", "Nguyen", null, new DateTime(2020, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Truong", null, null });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle", "productsProductId" },
                values: new object[,]
                {
                    { 1, 1, "vi", "Áo nam", "ao-nam", "Sản phẩm áo thời trang nam", "Sản phẩm áo thời trang nam", null },
                    { 3, 2, "vi", "Áo nữ", "ao-nu", "Sản phẩm áo thời trang nữ", "Sản phẩm áo thời trang women", null },
                    { 5, 3, "vi", "Máy ảnh", "may-anh", "may anh", "may anh", null },
                    { 6, 4, "vi", "Giày", "giay", "giay nam", "giay nam", null },
                    { 7, 5, "vi", "Quần nam", "quan-nam", "quan-nam", "quan-nam", null },
                    { 2, 1, "en", "Men Shirt", "men-shirt", "The shirt products for men", "The shirt products for men", null },
                    { 4, 2, "en", "Women Shirt", "women-shirt", "The shirt products for women", "The shirt products for women", null }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "IsFeatured", "ViewCount", "idBrand", "idColor", "idSize", "idType" },
                values: new object[,]
                {
                    { 1, null, 0, "1", "While", "L", "VIP" },
                    { 2, null, 0, "1", "While", "L", "VIP" },
                    { 3, null, 0, "1", "While", "L", "VIP" },
                    { 4, null, 0, "1", "While", "L", "VIP" },
                    { 5, null, 0, "1", "While", "L", "VIP" },
                    { 6, null, 0, "1", "While", "L", "VIP" },
                    { 7, null, 0, "1", "While", "L", "VIP" },
                    { 8, null, 0, "1", "While", "L", "VIP" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "ProductId", "idCategory" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 1 },
                    { 6, 1 },
                    { 5, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "productDetails",
                columns: new[] { "idProductDetail", "CategoryidCategory", "LanguageId", "ProductId", "ProductName", "dateAdded", "detail", "expiredSalingDate", "isSaling", "price", "salePrice" },
                values: new object[,]
                {
                    { 2, null, "vi", 2, "Pro", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "20", "10" },
                    { 1, null, "vi", 1, "Shoe", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "goood product", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "10", "10" }
                });

            migrationBuilder.InsertData(
                table: "productPhotos",
                columns: new[] { "Id", "Caption", "FileSize", "ImagePath", "IsDefault", "SortOrder", "idProduct", "uploadedTime" },
                values: new object[,]
                {
                    { 3, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 3, 3, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(671) },
                    { 7, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 7, 7, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(689) },
                    { 4, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 4, 4, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(678) },
                    { 5, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 5, 5, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(681) },
                    { 1, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 1, 1, new DateTime(2020, 12, 20, 2, 10, 46, 306, DateTimeKind.Local).AddTicks(2518) },
                    { 6, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 6, 6, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(686) },
                    { 2, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 2, 2, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(601) },
                    { 8, "Thumbnail image", 53562L, "/user-content/7d4eec52-45fa-4433-9465-46cf469805e8.jpg", true, 8, 8, new DateTime(2020, 12, 20, 2, 10, 46, 308, DateTimeKind.Local).AddTicks(692) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

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
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_usersId",
                table: "Orders",
                column: "usersId");

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
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "OrderDetails");

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
                name: "Slides");

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "productDetails");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "products");

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

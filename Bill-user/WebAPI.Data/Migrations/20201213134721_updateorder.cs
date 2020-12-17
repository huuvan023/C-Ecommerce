using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class updateorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_OrdersDetails_ordersDetailsidOrder",
                table: "products");

            migrationBuilder.DropTable(
                name: "ordersLists");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_products_ordersDetailsidOrder",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ordersDetailsidOrder",
                table: "products");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "e3757864-b342-4b52-aea3-7e9dc6b69964");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d1f3f95c-e947-48e5-a592-a60d627ec0cb", "AQAAAAEAACcQAAAAEO212fLjZTgi9kgvVBn3ilmJQqUjTYmnGi62eKPCKH6VtOygOwF+rBnuzqxUMICYyw==" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ordersDetailsidOrder",
                table: "products",
                type: "VARCHAR(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    idOrder = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idVoucher = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    status = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    totalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.idOrder);
                });

            migrationBuilder.CreateTable(
                name: "ordersLists",
                columns: table => new
                {
                    idOrder = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    idProduct = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "65cf2c67-f62f-4ea7-93cf-c15ff4118f1f");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cd43848-ecad-474a-872f-7655a7ee96f2", "AQAAAAEAACcQAAAAEJmRnJRNMLVXyauuTSZXN9tBJfke/YRUqY0swQt5SBkevlbs9f3KJ7w5iUWaxHGGCw==" });

            migrationBuilder.CreateIndex(
                name: "IX_products_ordersDetailsidOrder",
                table: "products",
                column: "ordersDetailsidOrder");

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

            migrationBuilder.AddForeignKey(
                name: "FK_products_OrdersDetails_ordersDetailsidOrder",
                table: "products",
                column: "ordersDetailsidOrder",
                principalTable: "OrdersDetails",
                principalColumn: "idOrder",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

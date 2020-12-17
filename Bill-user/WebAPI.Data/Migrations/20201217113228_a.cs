using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Languages_LanguageId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_LanguageId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "fdc8eda1-43bc-4dc6-8666-418f864aed1b");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "050853e1-0219-4042-8b6c-c18dee0f5ac3", "AQAAAAEAACcQAAAAEJzo3jQrTTctRHBNEUl6NMb454QIzQ8HPkCdropF5bvd7HgsFcfv6yFbrH6dxwIrAw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Languages_LanguageId",
                table: "Orders",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Languages_LanguageId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c6f62c93-63a7-4041-8f1e-3200e8ffcf63");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5ba44e0f-dbb8-4bb2-a4bd-c2ee60f749c3", "AQAAAAEAACcQAAAAEBHgEJb42WESOcpac5NYFzLbQqtpx8v4Y1PGw0qx31rx9kX8kdOkuC7cHLnqZmEwWA==" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LanguageId",
                table: "OrderDetails",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Languages_LanguageId",
                table: "OrderDetails",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

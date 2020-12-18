using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class upluague : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "5a2b6707-b3f9-4507-b581-2d8cfe015d7f");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b7a98f5-816d-4361-b572-fb0e42167d71", "AQAAAAEAACcQAAAAEFAvo1Yof9b/WX7In3uvmneNi7QDZochT5hvdZ9ghLKOG5XvgaUnSaAXXbDOuDwkag==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "4afaa8ff-f73d-497b-8fa8-843ec804a494");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40a180f4-1222-430c-a165-7f50fdbb88a0", "AQAAAAEAACcQAAAAEESwsc3v2ahDcDGx17HqbFRmrUoS5S516IbFziVZlI/LHKyoXc++hl0kSCkvI0ISeQ==" });
        }
    }
}

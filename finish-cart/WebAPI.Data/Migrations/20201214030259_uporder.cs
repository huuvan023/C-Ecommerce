using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class uporder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b7ce6a02-a8be-4b26-83a2-05a507e837a2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "801eebea-d83f-4507-8087-72437fba3c53", "AQAAAAEAACcQAAAAELhczEngvqHoJkHQeqtgnGmDwyaDcSe7RFGyu/Ffz8ryOFym2oeBSkJ3z5NS+5GroA==" });
        }
    }
}

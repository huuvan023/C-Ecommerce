using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class updateorder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

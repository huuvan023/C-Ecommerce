using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "70d5a17b-b219-4a2b-9462-cec9dae4d241");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5badaa8-5ac1-48e6-9304-bbd31345da1e", "AQAAAAEAACcQAAAAEP/uudFivpcaO2TevrH+/Dg7lOZFDqx2FLNBkGHUiKO27NF1OCJIBhSYN2RlX7Xy2w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bb8a6e48-856e-4819-89b6-7ed763a9099e");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cba197ce-c5fa-4c3e-b05c-7cd09edc2d0b", "AQAAAAEAACcQAAAAEIT5nmhOT7Ckv5yUSLAUcQOmFWggB4Yt5r9MhZkGTndlnNBKaSX5jUCfL5Jbtg6XlA==" });
        }
    }
}

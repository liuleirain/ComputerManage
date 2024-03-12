using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class GroupAddDesFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1aed6fb5-19d6-4a98-ba5f-fc88f72a5661");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ca02eff-d6e2-4af2-b399-238c48602dee", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17078a4e-0166-4bb2-95ca-e5a808fc3869", "AQAAAAEAACcQAAAAEH0Sy8IZAfbRejqEmJ43SznAYvIUrZevHFm31wHeM7P9+L83xB2F6v714cgwWfWX3Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ca02eff-d6e2-4af2-b399-238c48602dee");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Groups");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1aed6fb5-19d6-4a98-ba5f-fc88f72a5661", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ece18be2-c8b4-4c2f-bf17-0734ba4a3ca5", "AQAAAAEAACcQAAAAEI7Z//8TgmQc4afIApTejzl6ZkFiriMqoxOFMjEotOVekaqyXrMkXatL3Lpmswx0vw==" });
        }
    }
}

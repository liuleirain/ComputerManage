using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class changesomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e0cba8c-9f5e-4f0b-aae3-90dbcf7d2b92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fddd7fd-37a8-40ee-9b7a-de5713192cf6", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31e211f7-c89f-440f-92e9-31bcba487de2", "AQAAAAEAACcQAAAAEP5kpzfsiaYvBZOgpZh3AQbesGFHCEMZlsqbRqlw28TldwJJ8oVPvfPlD5UrgxW5PQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingGroups_GroupName",
                table: "WorkingGroups",
                column: "GroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments",
                column: "DepartmentName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkingGroups_GroupName",
                table: "WorkingGroups");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fddd7fd-37a8-40ee-9b7a-de5713192cf6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e0cba8c-9f5e-4f0b-aae3-90dbcf7d2b92", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc2b6416-6fb9-432e-8bd5-ab87e55b4881", "AQAAAAEAACcQAAAAEFIRoCwGvo1OwTZ3Asw7+30Iq4xrItLVZOm7tv9nsnS8+vh5ThvOZtANYTEERjbSYg==" });
        }
    }
}

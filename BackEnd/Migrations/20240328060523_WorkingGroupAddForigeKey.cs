using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class WorkingGroupAddForigeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "882177c2-d894-49a6-bd6f-1ef92229b6a7");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "WorkingGroups",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkingGroups_DepartmentId",
                table: "WorkingGroups",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingGroups_Departments_DepartmentId",
                table: "WorkingGroups",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingGroups_Departments_DepartmentId",
                table: "WorkingGroups");

            migrationBuilder.DropIndex(
                name: "IX_WorkingGroups_DepartmentId",
                table: "WorkingGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e0cba8c-9f5e-4f0b-aae3-90dbcf7d2b92");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "WorkingGroups");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "882177c2-d894-49a6-bd6f-1ef92229b6a7", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3ff5440-9767-414a-85de-0263e1e5ce3b", "AQAAAAEAACcQAAAAED9ygY9xXJwShEhRbGSZPCMNE7askJELW8yN2yNyD97hIXuwU9dlj+C4mUZZeJTZQA==" });
        }
    }
}

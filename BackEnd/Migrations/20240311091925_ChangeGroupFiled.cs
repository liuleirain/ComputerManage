using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class ChangeGroupFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Department_DepartmentId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Groups_GroupId",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ca02eff-d6e2-4af2-b399-238c48602dee");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WorkingGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingGroups", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f60c7c6-a269-45a5-8a1c-56a193523d1c", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1630f0a3-51c7-462f-94fe-b241524e4ff0", "AQAAAAEAACcQAAAAELxa84ttbSkIdgmcZFJVcV2aeSir/bAx2kd8gaYQq+UAET75DXSziRKXQ5yahlkJ+Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Departments_DepartmentId",
                table: "Computers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_WorkingGroups_GroupId",
                table: "Computers",
                column: "GroupId",
                principalTable: "WorkingGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Departments_DepartmentId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_WorkingGroups_GroupId",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "WorkingGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f60c7c6-a269-45a5-8a1c-56a193523d1c");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Department_DepartmentId",
                table: "Computers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Groups_GroupId",
                table: "Computers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}

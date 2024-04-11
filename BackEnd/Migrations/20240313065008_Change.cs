using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_AspNetUsers_AdministratorId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Departments_DepartmentId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_WorkingGroups_GroupId",
                table: "Computers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4b3cda8-77bd-4f88-83d1-ea61f6d7c883");

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "Computers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "Computers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Computers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_AspNetUsers_AdministratorId",
                table: "Computers",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_Computers_AspNetUsers_AdministratorId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Departments_DepartmentId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_WorkingGroups_GroupId",
                table: "Computers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "882177c2-d894-49a6-bd6f-1ef92229b6a7");

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "Computers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "Computers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Computers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4b3cda8-77bd-4f88-83d1-ea61f6d7c883", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f784d60-261a-4030-ae0a-4740cfc0abc2", "AQAAAAEAACcQAAAAEOR8neSOylrr/cRYe3aeFmq8Sorw2bt9Phu6xirMJ+Xgzp4rEHliRGJNl8Wnk07Y4A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_AspNetUsers_AdministratorId",
                table: "Computers",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Departments_DepartmentId",
                table: "Computers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_WorkingGroups_GroupId",
                table: "Computers",
                column: "GroupId",
                principalTable: "WorkingGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

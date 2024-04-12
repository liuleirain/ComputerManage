using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class changeComputerFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkingGroups_GroupName",
                table: "WorkingGroups");

            migrationBuilder.DropIndex(
                name: "IX_Computers_HostName",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_IpAddress",
                table: "Computers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fddd7fd-37a8-40ee-9b7a-de5713192cf6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08a8dd89-2133-4c52-991b-b7e9d3dcf4a1", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04f86b07-f238-4605-9157-84ba9efb86cc", "AQAAAAEAACcQAAAAEDIY+LVWDgYroAEFfsnT2Y6CebAqq2XzP9aWZh35xq7Z7pBGVBpCjGjzhVwyijdPqg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08a8dd89-2133-4c52-991b-b7e9d3dcf4a1");

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
                name: "IX_Computers_HostName",
                table: "Computers",
                column: "HostName",
                unique: true,
                filter: "[HostName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_IpAddress",
                table: "Computers",
                column: "IpAddress",
                unique: true,
                filter: "[IpAddress] IS NOT NULL");
        }
    }
}

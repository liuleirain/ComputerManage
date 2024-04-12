using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerManage.Migrations
{
    public partial class change1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08a8dd89-2133-4c52-991b-b7e9d3dcf4a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0807fa6-07c1-4c13-b605-408525c6d6fe", "2", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad34ec72-5813-4b61-abcd-4a50f8abcb9f", "AQAAAAEAACcQAAAAEFiSzM5jc8Uu/qAAMgOzhGAJtBo+RxEh21WM9VbXAZVdilY4dSq/pQmk7AAr6LQ2iQ==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Computers_HostName",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_IpAddress",
                table: "Computers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0807fa6-07c1-4c13-b605-408525c6d6fe");

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
    }
}

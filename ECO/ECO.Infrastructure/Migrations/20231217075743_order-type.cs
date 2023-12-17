using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class ordertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "284297f0-5155-490b-948b-43902926a950");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a349b50f-5292-43b1-b76b-f27f9c365a40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daac049f-3367-4ae8-8583-ce64fa75cf1c");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "28987e09-4e35-4cd6-abc9-17d35b34b680", "05326644-8d4a-41f5-af9b-1ac8c7ebd820", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "c428c010-f8f2-472b-a06a-ce212aee8e78", "8a1a6b60-2bb6-4a4f-b316-ee23f79a2c95", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "ef11a96b-0465-4c3a-bfa1-6ac1c4812061", "a72db4c8-b068-48c1-9e05-66ae84852654", "Customer", "AppRole", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28987e09-4e35-4cd6-abc9-17d35b34b680");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c428c010-f8f2-472b-a06a-ce212aee8e78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef11a96b-0465-4c3a-bfa1-6ac1c4812061");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "OrderDetail");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "284297f0-5155-490b-948b-43902926a950", "0195fe33-5821-45b1-9ea7-f409021e1bf2", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "a349b50f-5292-43b1-b76b-f27f9c365a40", "123963f9-e252-40fa-afb5-2d22475daab1", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "daac049f-3367-4ae8-8583-ce64fa75cf1c", "7aa5760a-4c04-483e-b4f1-50941b27d73a", "Customer", "AppRole", "Customer", "CUSTOMER" });
        }
    }
}

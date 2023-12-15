using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class cartItemUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a11f6af-9658-498a-90e4-c944a873bf6e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeaa99e7-d0d8-4a16-9a40-37b3f683cfba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e83ff966-5c36-43f4-863b-24ab03db62a2");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "6e86fab8-a5c5-4af5-bb49-242a3eaf5c07", "32bf24ab-bc91-4260-b0a9-e4348a26ef1e", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "78523798-c18f-4f06-8e0b-8775c3e05e5d", "0f34cf4a-6cbc-4a2e-bd5f-37b4c8ea3db0", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "b2deaf07-3d45-40d2-9ce9-ba52e0ed4609", "4562e1c3-9398-408c-b8d0-74102d01c893", "Customer", "AppRole", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e86fab8-a5c5-4af5-bb49-242a3eaf5c07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78523798-c18f-4f06-8e0b-8775c3e05e5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2deaf07-3d45-40d2-9ce9-ba52e0ed4609");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "CartItem");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "2a11f6af-9658-498a-90e4-c944a873bf6e", "17bf8c98-32ad-4c28-a201-9bf1749cfd4c", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "aeaa99e7-d0d8-4a16-9a40-37b3f683cfba", "b3ea4d2b-e3de-4ec3-81b8-a7ac51a01249", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "e83ff966-5c36-43f4-863b-24ab03db62a2", "a3c04bcb-43e0-4b78-8738-97d00c24cc0e", "Customer", "AppRole", "Customer", "CUSTOMER" });
        }
    }
}

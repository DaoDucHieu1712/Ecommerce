using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class resourcev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ac154d7-e01f-4252-a55b-75ead628d181");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77fb0b35-87e4-4b3f-85c4-b5fd36364709");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9fe6e63-95de-401d-af36-c49636ca0d00");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Resource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "161c538e-aab1-4fc8-bfa6-aa8519590c20", "02e52ea0-e105-47cd-bc0d-220b29b44be0", "Customer", "AppRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8bef618c-4d7a-49e3-8331-9bedda57a18d", "885c77d2-1f9a-4ca6-a93d-4fd6868d0ffb", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "b0895973-189c-4859-bfe8-f86edf38ca3c", "393d0b51-3eba-422c-8400-6ae75036b9fa", "Admin", "AppRole", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "161c538e-aab1-4fc8-bfa6-aa8519590c20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bef618c-4d7a-49e3-8331-9bedda57a18d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0895973-189c-4859-bfe8-f86edf38ca3c");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Resource");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "0ac154d7-e01f-4252-a55b-75ead628d181", "e03a73c3-0b8b-4f2f-aacd-382e697c7d14", "Customer", "AppRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "77fb0b35-87e4-4b3f-85c4-b5fd36364709", "cd1267b3-ecc8-4a9f-95fb-4bd77494edb2", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "d9fe6e63-95de-401d-af36-c49636ca0d00", "378a4d49-4bc1-4462-be66-5e9c3039e45e", "Admin", "AppRole", "Admin", "ADMIN" });
        }
    }
}

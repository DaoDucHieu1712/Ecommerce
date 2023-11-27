using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class resourcev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30afc12e-dc4c-4e07-be46-7346f7f0e4ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f6166e3-2ad9-4388-91e2-c0d96e0aefe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b732b7df-97ff-4234-8bda-53e31fc8989a");

            migrationBuilder.AddColumn<string>(
                name: "PathId",
                table: "Resource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PathId",
                table: "Resource");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "30afc12e-dc4c-4e07-be46-7346f7f0e4ae", "98d94e2d-aea0-4a02-9b06-02e9a95d0cb6", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8f6166e3-2ad9-4388-91e2-c0d96e0aefe0", "0dea884d-a402-4d82-b7de-63f0845870c5", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "b732b7df-97ff-4234-8bda-53e31fc8989a", "d3048710-5612-4126-bf08-cb20f1e17431", "Customer", "AppRole", "Customer", "CUSTOMER" });
        }
    }
}

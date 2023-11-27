using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class resource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41bcd648-443a-4d91-812c-8acac861b982");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f7c0cce-bc9f-48e4-8e44-148938ef4156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dc9ebc4-8ee2-459c-8bda-a232ce0bd396");

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resource");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "41bcd648-443a-4d91-812c-8acac861b982", "d4e4cb66-2c41-495e-abc6-2e75721392cb", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "5f7c0cce-bc9f-48e4-8e44-148938ef4156", "d49f51b0-bc53-4980-b3c1-cd7e74a3d78d", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8dc9ebc4-8ee2-459c-8bda-a232ce0bd396", "0a6ac210-cabb-420e-b54a-61b6eb69f5e3", "Customer", "AppRole", "Customer", "CUSTOMER" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class cartitemupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_InventoryId",
                table: "CartItem",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Inventory_InventoryId",
                table: "CartItem",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Inventory_InventoryId",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_InventoryId",
                table: "CartItem");

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

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "CartItem");

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
    }
}

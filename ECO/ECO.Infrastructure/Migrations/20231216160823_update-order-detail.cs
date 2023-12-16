using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class updateorderdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12187cf1-e65d-4d5c-9e91-99e229563291");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a27cb5a-2039-4fb0-94d5-acd899f26bd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5635140c-f6b5-4d70-bd9e-94d9d8e9a0f7");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "OrderDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "OrderDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "2ca852b9-8fc3-45e7-aa8c-8ea39c21a749", "43f89cf1-4a88-4edc-981d-4370ef5cfaf8", "Customer", "AppRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "c245fb5b-348b-4ea9-a82a-fc18cfb7edb7", "b9e8d0f4-74a5-420f-b12e-bd3945db1dad", "Staff", "AppRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "cf8c8a3b-f70d-4c1d-b64e-2a6eb8406b74", "ae1136fe-f779-4681-9c28-7d009cb96c88", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_InventoryId",
                table: "OrderDetail",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Inventory_InventoryId",
                table: "OrderDetail",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Inventory_InventoryId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_InventoryId",
                table: "OrderDetail");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ca852b9-8fc3-45e7-aa8c-8ea39c21a749");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c245fb5b-348b-4ea9-a82a-fc18cfb7edb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf8c8a3b-f70d-4c1d-b64e-2a6eb8406b74");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "12187cf1-e65d-4d5c-9e91-99e229563291", "138e84f1-3af7-426d-8273-379d91386104", "Customer", "AppRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "1a27cb5a-2039-4fb0-94d5-acd899f26bd5", "4cc8fef5-d357-4501-a313-4522ea914cd0", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "5635140c-f6b5-4d70-bd9e-94d9d8e9a0f7", "ce9e7462-19cb-4ec1-9a61-0f9e43894bc8", "Staff", "AppRole", "Staff", "STAFF" });
        }
    }
}

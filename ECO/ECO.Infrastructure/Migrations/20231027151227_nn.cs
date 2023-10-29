using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class nn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Color_ColorId1",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_ProductId1",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Size_SizeId1",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Color_ColorId1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Size_SizeId1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_AppUserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Product_ProductId1",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_AppUserId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ProductId1",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ColorId1",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderId1",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId1",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_SizeId1",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ColorId1",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ProductId1",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_SizeId1",
                table: "Inventory");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1926bb1a-b585-47d3-be0f-06ef0c88c942");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a9b51d2-52c8-4bb5-ba60-7819f7d8e54e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5923710-88c4-4875-874a-b310c894389a");

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ColorId1",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "SizeId1",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ColorId1",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "SizeId1",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Rating",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Rating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId1",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId1",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId1",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId1",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1926bb1a-b585-47d3-be0f-06ef0c88c942", "ef2834f1-a26b-46cb-be7d-d1f1a8d10564", "Customer", "AppRole", "Customer", "CUSTOMER" },
                    { "5a9b51d2-52c8-4bb5-ba60-7819f7d8e54e", "518f1fb4-7836-4cdd-a236-1360eb134f3e", "Admin", "AppRole", "Admin", "ADMIN" },
                    { "e5923710-88c4-4875-874a-b310c894389a", "0bbf5909-fd20-41a6-9551-f1f896bf29d9", "Staff", "AppRole", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "SizeName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "S", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "M", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "L", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "XL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "2XL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "3XL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "4XL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AppUserId",
                table: "Rating",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProductId1",
                table: "Rating",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ColorId1",
                table: "OrderDetail",
                column: "ColorId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId1",
                table: "OrderDetail",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId1",
                table: "OrderDetail",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SizeId1",
                table: "OrderDetail",
                column: "SizeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ColorId1",
                table: "Inventory",
                column: "ColorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId1",
                table: "Inventory",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SizeId1",
                table: "Inventory",
                column: "SizeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Color_ColorId1",
                table: "Inventory",
                column: "ColorId1",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_ProductId1",
                table: "Inventory",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Size_SizeId1",
                table: "Inventory",
                column: "SizeId1",
                principalTable: "Size",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Color_ColorId1",
                table: "OrderDetail",
                column: "ColorId1",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId1",
                table: "OrderDetail",
                column: "OrderId1",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId1",
                table: "OrderDetail",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Size_SizeId1",
                table: "OrderDetail",
                column: "SizeId1",
                principalTable: "Size",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AspNetUsers_AppUserId",
                table: "Rating",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Product_ProductId1",
                table: "Rating",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}

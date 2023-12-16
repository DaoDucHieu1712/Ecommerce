using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class updateorderdetail_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Color_ColorId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Size_SizeId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ColorId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_SizeId",
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
                name: "ColorId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "OrderDetail");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "94acac8d-ee9b-4138-98fd-78a6c0912843", "e635c600-56ce-47dd-825b-45c7053aed33", "Customer", "AppRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "d3a327ca-f469-403b-b0d1-9f489e9f4fad", "0bd59da5-1595-45c5-87b4-c40de5c04851", "Admin", "AppRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "ff034d46-d470-4363-b0bf-c522ae2f0f3d", "d5e57788-9e02-4434-a5c0-194ec619b244", "Staff", "AppRole", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94acac8d-ee9b-4138-98fd-78a6c0912843");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3a327ca-f469-403b-b0d1-9f489e9f4fad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff034d46-d470-4363-b0bf-c522ae2f0f3d");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "OrderDetail",
                type: "int",
                nullable: true);

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
                name: "IX_OrderDetail_ColorId",
                table: "OrderDetail",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SizeId",
                table: "OrderDetail",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Color_ColorId",
                table: "OrderDetail",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Size_SizeId",
                table: "OrderDetail",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id");
        }
    }
}

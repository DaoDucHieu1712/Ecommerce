using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECO.Infrastructure.Migrations
{
    public partial class payment_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_PaymentId",
                table: "Order",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_PaymentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentId",
                table: "Order");

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

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}

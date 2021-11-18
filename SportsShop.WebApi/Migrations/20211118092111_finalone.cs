using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsShop.WebApi.Migrations
{
    public partial class finalone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_ItemNumber1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemNumber1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemNumber1",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderNumber",
                table: "Items",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OrderNumber",
                table: "Customers",
                column: "OrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Orders_OrderNumber",
                table: "Customers",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrderNumber",
                table: "Items",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Orders_OrderNumber",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderNumber",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderNumber",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OrderNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "ItemNumber1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemNumber1",
                table: "Orders",
                column: "ItemNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_ItemNumber1",
                table: "Orders",
                column: "ItemNumber1",
                principalTable: "Items",
                principalColumn: "ItemNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

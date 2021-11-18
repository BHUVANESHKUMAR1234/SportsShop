using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsShop.WebApi.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_ItemNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemNumber",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ItemNumber1",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderAddress",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemNumber1",
                table: "Orders",
                column: "ItemNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_ItemNumber1",
                table: "Orders",
                column: "ItemNumber1",
                principalTable: "Items",
                principalColumn: "ItemNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Items_ItemNumber1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ItemNumber1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemNumber1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderAddress",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemNumber",
                table: "Orders",
                column: "ItemNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Items_ItemNumber",
                table: "Orders",
                column: "ItemNumber",
                principalTable: "Items",
                principalColumn: "ItemNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

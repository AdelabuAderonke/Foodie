using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodie.Migrations
{
    public partial class FoodieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodieOrderId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodieOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodieOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOrders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_FoodieOrderId",
                table: "FoodItems",
                column: "FoodieOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_FoodieOrders_FoodieOrderId",
                table: "FoodItems",
                column: "FoodieOrderId",
                principalTable: "FoodieOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodieOrders_FoodieOrderId",
                table: "FoodItems");

            migrationBuilder.DropTable(
                name: "FoodieOrders");

            migrationBuilder.DropTable(
                name: "PlaceOrders");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_FoodieOrderId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "FoodieOrderId",
                table: "FoodItems");
        }
    }
}

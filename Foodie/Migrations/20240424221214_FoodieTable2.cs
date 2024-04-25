using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodie.Migrations
{
    public partial class FoodieTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FoodItems",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FoodItems");
        }
    }
}

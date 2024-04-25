using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodie.Migrations
{
    public partial class First1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FoodItems");

            migrationBuilder.CreateTable(
                name: "AddFoodItemRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddFoodItemRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddFoodItemRequests");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "FoodItems",
                type: "int",
                nullable: true);
        }
    }
}

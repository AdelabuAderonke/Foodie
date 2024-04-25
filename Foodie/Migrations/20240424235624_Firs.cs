using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foodie.Migrations
{
    public partial class Firs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_FoodieOrders_FoodieOrderId",
                table: "FoodItems");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_FoodieOrderId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "FoodieOrderId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FoodItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FoodItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FoodieOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_FoodieOrders_FoodieOrderId",
                        column: x => x.FoodieOrderId,
                        principalTable: "FoodieOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodieOrderId",
                table: "OrderItems",
                column: "FoodieOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodItemId",
                table: "OrderItems",
                column: "FoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "FoodItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FoodieOrderId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FoodItems",
                type: "int",
                nullable: true);

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
    }
}

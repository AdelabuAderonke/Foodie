using Foodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Data
{
    public class FoodieDBContext : DbContext
    {
        public FoodieDBContext(DbContextOptions<FoodieDBContext> options)
            : base(options)
        {

        }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodieOrder> FoodieOrders { get; set; }
        public DbSet<PlaceOrder> PlaceOrders { get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        public DbSet<AddFoodItemRequest> AddFoodItemRequests { get; set; }
    }
}

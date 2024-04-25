namespace Foodie.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public FoodItem FoodItem { get; set; } // Reference to food item
        public int Quantity { get; set; }

    }
}

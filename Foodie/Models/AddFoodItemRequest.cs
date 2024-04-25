namespace Foodie.Models
{
    public class AddFoodItemRequest
    {
        public int Id { get; set; }
        public int FoodItemId { get; set; } 
        public int Quantity { get; set; }
    }
}

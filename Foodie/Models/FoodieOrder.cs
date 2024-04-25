namespace Foodie.Models
{
    public class FoodieOrder 
    { 
            public int Id { get; set; }
            public List<OrderItem> FoodItems { get; set; }
            public DateTime OrderDate { get; set; }

        //public decimal TotalPrice => CalculateTotalPrice();
    }
}

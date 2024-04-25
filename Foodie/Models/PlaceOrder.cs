namespace Foodie.Models
{
    public class PlaceOrder
    {
        public int Id { get; set; }
        public decimal TotalCost { get; set; } // Total cost of the order
        public string Message { get; set; }
    }
}

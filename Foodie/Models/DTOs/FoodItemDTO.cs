using System.ComponentModel.DataAnnotations;

namespace Foodie.Models.DTOs
{
    public class FoodItemDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

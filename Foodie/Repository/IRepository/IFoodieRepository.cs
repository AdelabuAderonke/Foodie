using Foodie.Models;

namespace Foodie.Repository.IRepository
{
    public interface IFoodieRepository
    {
        //return all list of food items
        Task<List<FoodItem>> Menu();
    }
}

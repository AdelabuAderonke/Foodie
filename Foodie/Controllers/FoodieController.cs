using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodieController : ControllerBase
    {

        private readonly FoodieDBContext _foodieDBContext;

        public FoodieController(FoodieDBContext foodieDBContext)
        {

            _foodieDBContext = foodieDBContext;
        }
        [HttpGet("menu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FoodItemDTO>> GetMenu()
        {
            return Ok(_foodieDBContext.FoodItems.ToList());
        }

        [HttpPost("AddOrder")]
        public ActionResult AddItemToOrder([FromBody] AddFoodItemRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("invalid request!");
                }
                FoodItem foodItem = _foodieDBContext.FoodItems.FirstOrDefault(x => x.Id == request.FoodItemId);

                if (foodItem == null)
                {
                    return NotFound("Food item not found.");
                }
                OrderItem orderItem = new OrderItem
                {
                    FoodItem = foodItem,
                    Quantity = request.Quantity
                };

                List<OrderItem> userOrder = new List<OrderItem>();
                // Add the item to the order
                userOrder.Add(orderItem);

                return Ok(userOrder);
            }
            catch (Exception ex)
            {


                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpGet("current-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<FoodieOrder> GetCurrentOrder()
        {
            //  all order items from the database
            var orderItems = _foodieDBContext.OrderItems
                .Include(o => o.FoodItem)
                .ToList();

            // Calculate total cost
            decimal totalCost = orderItems.Sum(o => o.Quantity * o.FoodItem.Price);

            // Create a FoodieOrder for  the current order
            var foodieOrder = new FoodieOrder
            {
                FoodItems = orderItems.Select(o => o).ToList(),
                OrderDate = DateTime.Now 
            };

            return Ok(foodieOrder);
        }
        [HttpPost("place-order")]
        public IActionResult PlaceOrder()
        {
            try
            {
                // Fetch order items from the database
                var orderItems = _foodieDBContext.OrderItems
                    .Include(o => o.FoodItem)
                    .ToList();

                // Calculate total cost including taxes and discounts
                decimal totalCost = CalculateTotalCost(orderItems);

                // Clear the user's order from the database
                _foodieDBContext.OrderItems.RemoveRange(orderItems);
                _foodieDBContext.SaveChanges();

                // Return total cost and confirmation message
                return Ok(new { TotalCost = totalCost, Message = "Order placed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        private decimal CalculateTotalCost(IEnumerable<OrderItem> orderItems)
        {
            decimal SumCost = orderItems.Sum(o => o.Quantity * o.FoodItem.Price);


            // Apply 10% tax
            SumCost = SumCost * 0.1m;
            //Apply  5% Discount to  order > $50
            if (SumCost > 50)
            {
                SumCost = SumCost - (0.05m * SumCost);
            }
            return SumCost;
        }

    }
}


using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishes.Command.CreateDishCommand;
using Restaurant.Application.Dishes.Command.DeleteDishCommand;
using Restaurant.Application.Dishes.Command.UpdateDishCommand;
using Restaurant.Application.Dishes.Query.GetAllDishesForRestaurant;
using Restaurant.Application.Dishes.Query.GetAllDishesByCategories;
using Restaurant.Application.Dishes.Query.GetDishByIdforRestaurant.GetDishByIdforRestaurantQuery;

namespace Restaurant.UI.Controllers
{
    [Route("api/restaurant/{restaurantId}/[Controller]")]
    [ApiController]
    public class DishController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDishesforRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetAllDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{DishId}")]
        public async Task<IActionResult> GetDishByIdforRestaurant([FromRoute] int restaurantId, [FromRoute] int DishId)
        {
            var dish = await mediator.Send(new GetDishByIdforRestaurantQuery(restaurantId, DishId));
            return Ok(dish);
        }

        [HttpPut("{DishId}")]
        public async Task<IActionResult> UpdateDishForRestaurant([FromRoute] int restaurantId, [FromRoute] int DishId, UpdateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            command.DishId = DishId;
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{DishId}")]
        public async Task<IActionResult> DeleteDish([FromRoute] int restaurantId, [FromRoute] int DishId)
        {
            await mediator.Send(
                new DeleteDishCommand(restaurantId, DishId));

            return NoContent();
        }


        [HttpGet("/api/dishes/category/{category}")]
        public async Task<IActionResult> GetDishesByCategory(string category)
        {
            var result = await mediator.Send(new GetAllDishesByCategoryQuery
            {
                Category = category
            });

            return Ok(result);
        }



    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Commands.CreateRestaurant;
using Restaurant.Application.Commands.DeleteRestaurant;
using Restaurant.Application.Commands.UpdateRestaurant;
using Restaurant.Application.DTO;
using Restaurant.Application.Queries.GetAll;
using Restaurant.Application.Queries.GetRestaurantByID;
using Restaurant.Application.Queries.Search;



namespace Restaurant.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IMediator service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllQuery query)
        {
            var restaurant = await service.Send(query);
            return Ok(restaurant);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            //var restaurant = await service.Send(new GetRestaurantbyIDQuery(id));
            //if (restaurant == null)
            //    return NotFound($"Could not find restaurant with ID : {id}");

            //return Ok(restaurant); 
            var restaurant = await service.Send(new GetRestaurantbyIDQuery(id));

            return Ok(restaurant);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand createRestaurantDTO)
        {

            var id = await service.Send(createRestaurantDTO);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            //var restaurant = await service.Send(new DeleteRestaurantQuery(id));
            //if (!restaurant)
            //    return NotFound($"Could not find restaurant with ID : {id}");

            //return NoContent();

            await service.Send(new DeleteRestaurantQuery(id));
            //if (!restaurant)
            //    return NotFound($"Could not find restaurant with ID : {id}");

            return NoContent();


        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand updateRestaurant)
        {
            updateRestaurant.Id = id;
            await service.Send(updateRestaurant);

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchRestaurantQuery query)
        {
            var result = await service.Send(query);
            return Ok(result);
        }

    }
}

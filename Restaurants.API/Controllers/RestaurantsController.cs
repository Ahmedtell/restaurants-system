using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetById(id);
            if (restaurant == null)
            {
                return NotFound($"Restaurant with id {id} not found");
            }
            return Ok($"Restaurant with id {id} is found, Restaurant name: {restaurant.Name}");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            int id = await restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}

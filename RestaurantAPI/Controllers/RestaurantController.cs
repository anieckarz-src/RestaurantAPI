using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestaurantAPI.Controllers
{

    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRestaurantDto dto,[FromRoute] int id)
        {
   
            _restaurantService.Update(dto,id);

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {

            int id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}",null);
        }

        [HttpGet]
        [Authorize(Policy ="Atleast20")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery] RestaurantQuery query)
        {
            var restaurantsDtos = _restaurantService.GetAll(query);
            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurantDto = _restaurantService.GetById(id);

            return Ok(restaurantDto);
        }
    }
}

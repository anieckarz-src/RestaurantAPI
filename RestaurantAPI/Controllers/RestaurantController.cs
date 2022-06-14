using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Controllers
{

    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restourants = _dbContext
                .Restaurants
                .ToList();
            return Ok(restourants);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restourant = _dbContext
                .Restaurants
                .FirstOrDefault(x => x.Id == id);

            if(restourant == null)
            {
                return NotFound();
            }

            return Ok(restourant);
        }
    }
}

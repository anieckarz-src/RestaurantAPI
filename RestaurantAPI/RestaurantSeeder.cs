using RestaurantAPI.Data;
using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description ="KFC short for Kentucky Friend Chicken",
                    ContactEmail ="contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Hot Chicken",
                            Price = 10.20M,
                        },
                        new Dish()
                        {
                            Name = "Chiken Nuggets",
                            Price =5.20M,
                        }
                    },
                    Address = new Address()
                    {
                        City="Krakow",
                        Street="Dluga 5",
                        PostalCode="20231-2"
                    }
                }
            };
            return restaurants;
        }
    }
}

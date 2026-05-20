using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurants);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()

        {
            List<Restaurant> restaurants = [
                new Restaurant
                { 
                    Name = "KFC",
                    Description = "Fried chicken fast food restaurant",
                    Category = "Fast Food",
                    ContactEmail = "contact@kfc.com",
                    ContactNumber = "+100000001",
                    Address = new Address { City = "New York", Street = "Broadway Street", PostalCode = "10001" },
                    Dishes = [
                        new() { Name = "Zinger Burger", Description = "Spicy crispy chicken burger", Price = 9.99m, KiloCalories = 550 },
                        new() { Name = "Chicken Bucket", Description = "Fried chicken bucket with fries", Price = 15.50m, KiloCalories = 2200 }
                    ]
                },
                new Restaurant
                {
                    Name = "Pizza Hut",
                    Description = "Famous pizza restaurant",
                    Category = "Italian",
                    ContactEmail = "info@pizzahut.com",
                    ContactNumber = "+100000002",
                    Address = new Address { City = "Chicago", Street = "Lake Street", PostalCode = "60601" },
                    Dishes = [
                        new() { Name = "Pepperoni Pizza", Description = "Pizza with pepperoni and cheese", Price = 12.99m, KiloCalories = 300 },
                        new() { Name = "Cheese Pizza", Description = "Classic cheese pizza", Price = 10.50m, KiloCalories = 250 }
                    ]
                },
                new Restaurant
                {
                    Name = "Sushi World",
                    Description = "Fresh Japanese sushi restaurant",
                    Category = "Japanese",
                    ContactEmail = "hello@sushiworld.com",
                    ContactNumber = "+100000003",
                    Address = new Address { City = "Tokyo", Street = "Shibuya Center", PostalCode = "150-0002" },
                    Dishes = [
                        new() { Name = "Salmon Sushi", Description = "Fresh salmon over rice", Price = 18.75m, KiloCalories = 50 },
                        new() { Name = "Tuna Roll", Description = "Tuna roll with seaweed", Price = 17.25m, KiloCalories = 45 }
                    ]
                },
                new Restaurant
                {
                    Name = "Burger King",
                    Description = "Flame-grilled burgers",
                    Category = "Fast Food",
                    ContactEmail = "info@burgerking.com",
                    ContactNumber = "+100000004",
                    Address = new Address { City = "Los Angeles", Street = "Sunset Blvd", PostalCode = "90001" },
                    Dishes = [
                        new() { Name = "Whopper", Description = "Flame-grilled beef burger", Price = 11.99m, KiloCalories = 660 },
                        new() { Name = "Fries", Description = "Crispy golden fries", Price = 4.50m, KiloCalories = 350 }
                    ]
                }
            ];
            return restaurants;
        }
    }
}
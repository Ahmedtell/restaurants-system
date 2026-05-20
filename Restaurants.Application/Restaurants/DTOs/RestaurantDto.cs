using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Restaurants.DTO
{
    public class RestaurantDto
    { 
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasdDelivery { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public List<DishDto> Dishes { get; set; } = [];

        //public static RestaurantDto? FromEntity(Restaurant? restaurant)
        //{
        //    if (restaurant == null) return null!;

        //    return new RestaurantDto
        //    {
        //        ID = restaurant.ID,
        //        Name = restaurant.Name,
        //        Description = restaurant.Description,
        //        Category = restaurant.Category,
        //        HasdDelivery = restaurant.HasDelivery,
        //        City = restaurant.Address?.City,
        //        Street = restaurant.Address?.Street,
        //        PostalCode = restaurant.Address?.PostalCode,
        //        Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()
        //    };
        //}


    }
}

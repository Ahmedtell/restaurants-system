using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Restaurants
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetByIdAsync(int id);
        Task<int> Create(Restaurant entity);
    }
}

using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Restaurants;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantsDbContext DbContext) : IRestaurantsRepository
    {
        public async Task<int> Create(Restaurant entity)
        {
            DbContext.Restaurants.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity.ID;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            var restaurants = await DbContext.Restaurants.Include(r => r.Dishes).ToListAsync();
            return restaurants;
        }
        public async Task<Restaurant> GetByIdAsync(int id)
        {
            var restaurant = await DbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.ID == id);
            return restaurant!;
        }

        public async Task Delete(Restaurant entity)
        {
            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Restaurant?> UpdateRestaurantById(int id, Restaurant entity)
        {
            var restaurant = await DbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.ID == id);
            return restaurant;
        }

        public Task SaveChanges()
         => DbContext.SaveChangesAsync();
    }
}

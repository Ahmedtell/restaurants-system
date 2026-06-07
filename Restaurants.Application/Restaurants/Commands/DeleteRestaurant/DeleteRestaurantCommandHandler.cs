using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Restaurants;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(
        ILogger<DeleteRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Restaurant with id: {request.id} has been deleted successfully");
            var restaurant = await restaurantsRepository.GetByIdAsync(request.id);
            if (restaurant is null)
                return false;
            await restaurantsRepository.Delete(restaurant);
            return true;
        }
    }
}

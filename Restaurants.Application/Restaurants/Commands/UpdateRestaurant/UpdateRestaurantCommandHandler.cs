using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Restaurants;
using System.Security.Cryptography.X509Certificates;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    internal class UpdateRestaurantCommandHandler(
        ILogger<UpdateRestaurantCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository,
        IMapper mapper
        ) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Updating restaurant with id {request.ID} has been deleted successfully");

            var restaurant = await restaurantsRepository.GetByIdAsync(request.ID);

            if (restaurant is null)
                return false;

            mapper.Map(request, restaurant);

            //restaurant.Name = request.Name;
            //restaurant.Description = request.Description;
            //restaurant.HasDelivery = request.HasDelivery;


            await restaurantsRepository.SaveChanges();

            return true;
        }
    }
}

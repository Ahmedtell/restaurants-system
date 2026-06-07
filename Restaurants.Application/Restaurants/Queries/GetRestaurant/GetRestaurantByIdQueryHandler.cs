
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Restaurants;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurant
{
    public class GetRestaurantByIdQueryHandler(
        ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) :
        IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
    {
        public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting specific restaurant: {request.id}");

            var restaurant = await restaurantsRepository.GetByIdAsync(request.id);

            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

            return restaurantDto;
        }
    }
}

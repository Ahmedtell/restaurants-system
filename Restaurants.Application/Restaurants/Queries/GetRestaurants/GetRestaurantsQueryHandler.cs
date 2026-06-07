using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Restaurants;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurants
{
    internal class GetRestaurantsQueryHandler(ILogger<GetRestaurantsQueryHandler> logger, IMapper mapper ,IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting All Restaurants");

            var restaurants = await restaurantsRepository.GetAllRestaurantsAsync();

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDtos!;
        }
    }
}

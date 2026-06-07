using MediatR;
using Restaurants.Application.Restaurants.DTO;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
    }
}

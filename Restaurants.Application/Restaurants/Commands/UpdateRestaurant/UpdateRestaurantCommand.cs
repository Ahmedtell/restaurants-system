using MediatR;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : IRequest<bool>
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool HasDelivery { get; set; }
    }
}

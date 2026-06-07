using MediatR;
using Restaurants.Application.Restaurants.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurant
{
    public class GetRestaurantByIdQuery  : IRequest<RestaurantDto?>
    {
        public GetRestaurantByIdQuery(int id)
        {
            this.id = id;
        }
        public int id { get; }
    }
}

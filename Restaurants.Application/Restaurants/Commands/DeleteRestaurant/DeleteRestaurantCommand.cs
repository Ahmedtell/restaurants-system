using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<bool>
    {
        public DeleteRestaurantCommand(int id)
        {
            this.id = id;
        }
        public int id { get; }
    }
}

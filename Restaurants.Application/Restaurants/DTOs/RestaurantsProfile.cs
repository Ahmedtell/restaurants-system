using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.DTO;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<UpdateRestaurantCommand, Restaurant>();

            // Map CreateRestaurant to Restaurant Entity 
            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(r => r.Address, opt => opt.MapFrom(
                    src => new Address
                    {
                        City = src.City,
                        PostalCode = src.PostalCode,
                        Street = src.Street,
                    }));

            // Map Restaurant entity to RestaurantDto
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.City, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(d => d.PostalCode, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
                .ForMember(d => d.Street, opt =>
                opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}

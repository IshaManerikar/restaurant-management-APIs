
using AutoMapper;
using Restaurant.Application.Commands.CreateRestaurant;
using Restaurant.Application.Commands.UpdateRestaurant;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.DTO
{
    internal class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Hotel, RestaurantDTO>()
                .ForMember(x => x.City, opt => opt.MapFrom(h => h.Address == null ? null : h.Address.City))
                .ForMember(x => x.Street, opt => opt.MapFrom(h => h.Address == null ? null : h.Address.Street))
                .ForMember(x => x.PostalCode, opt => opt.MapFrom(h => h.Address == null ? null : h.Address.PostalCode))
                .ForMember(x => x.DishDTO, opt => opt.MapFrom(h => h.Dishes));


            CreateMap<CreateRestaurantCommand, Hotel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode,
                }));

            CreateMap<UpdateRestaurantCommand, Hotel>();

          


        }
               
    }
}

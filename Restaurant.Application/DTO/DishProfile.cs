using AutoMapper;
using Restaurant.Application.Dishes.Command.CreateDishCommand;
using Restaurant.Application.Dishes.Command.UpdateDishCommand;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.DTO
{
    internal class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDTO>();
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<UpdateDishCommand, Dish>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

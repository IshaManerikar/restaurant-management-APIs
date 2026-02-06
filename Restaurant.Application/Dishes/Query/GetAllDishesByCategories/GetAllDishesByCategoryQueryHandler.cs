using AutoMapper;
using MediatR;
using Restaurant.Application.DTO;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Dishes.Query.GetAllDishesByCategories
{
    public class GetDishesQueryHandler : IRequestHandler<GetAllDishesByCategoryQuery, List<DishDTO>>
    {
        private readonly IDishRepository _repo;
        private readonly IMapper _mapper;

        public GetDishesQueryHandler(IDishRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<DishDTO>> Handle(GetAllDishesByCategoryQuery request, CancellationToken cancellationToken)
        {
            var dishes = await _repo.GetDishesByCategory(request.Category); // returns List<Dish>
            return _mapper.Map<List<DishDTO>>(dishes); // map to DTO
        }
    }

}

using MediatR;
using AutoMapper;
using Restaurant.Domain.IRepository;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Queries.Search
{
    public class SearchRestaurantQueryHandler : IRequestHandler<SearchRestaurantQuery, IEnumerable<RestaurantDTO>>
    {
        private readonly IRestaurantRepository _repository;
        private readonly IMapper _mapper;

        public SearchRestaurantQueryHandler(IRestaurantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantDTO>> Handle(SearchRestaurantQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.SearchAsync(request.Name, request.DishName, request.MinPrice, request.MaxPrice, request.Category, request.City);
            return _mapper.Map<IEnumerable<RestaurantDTO>>(result);
        }
    }
}

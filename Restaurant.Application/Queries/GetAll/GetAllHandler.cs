
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Common;
using Restaurant.Application.DTO;
using Restaurant.Domain.IRepository;

namespace Restaurant.Application.Queries.GetAll
{
    public class GetAllHandler(ILogger<GetAllHandler> logger,IMapper mapper,IRestaurantRepository repository) : IRequestHandler<GetAllQuery, MatchingRecords<RestaurantDTO>>
    {    //Test comment
        public async Task<MatchingRecords<RestaurantDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("getting all matched and sorted restaurants");
            var restaurants = await repository.GetAllMatchingAsync(request.searchPhrase, request.PageNumber,request.PageSize , request.SortBy, request.SortDirection );
            var result = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants.Items);
            var matchedRecords = new MatchingRecords<RestaurantDTO>();
            matchedRecords.Items = result;
            matchedRecords.ItemCount = restaurants.ItemCount;
            matchedRecords.PageCount = restaurants.PageCount;
            matchedRecords.FromIndex = restaurants.FromIndex;
            matchedRecords.ToIndex = restaurants.ToIndex;

            return matchedRecords;
        }
    }
}



using MediatR;
using Restaurant.Domain.Common;
using Restaurant.Application.DTO;

namespace Restaurant.Application.Queries.GetAll
{
    public class GetAllQuery() : IRequest<MatchingRecords<RestaurantDTO>>
    {
        public string? searchPhrase { get; set; }
        public int PageNumber  { get; set; }
        public int PageSize { get; set; }

        public string SortBy { get; set; }
        public SortOrder SortDirection { get; set; }
    }
}

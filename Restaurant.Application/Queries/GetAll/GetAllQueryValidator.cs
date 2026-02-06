
using FluentValidation;
using System.Data;

namespace Restaurant.Application.Queries.GetAll;

public class GetAllQueryValidator : AbstractValidator<GetAllQuery>
{
    private int[] allowedPageSizes = [5, 10, 15, 30];
    private string[] allowedSortOptions = ["Name" , "Description","Category"];
    public GetAllQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).Must(x => allowedPageSizes.Contains(x)).WithMessage("Allowed page sizes [5,10,15,30]");
        RuleFor(x => x.SortBy).Must(x => allowedSortOptions.Contains(x.ToString())).When(x => x != null)
            .WithMessage($"can be null but when supplied must be from [ {string.Join("", allowedSortOptions)}]");

    }
}

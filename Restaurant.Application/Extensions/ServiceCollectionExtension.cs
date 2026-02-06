using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace Restaurant.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceCollectionExtension).Assembly));
            services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly).AddFluentValidationAutoValidation();
        }
    }
}

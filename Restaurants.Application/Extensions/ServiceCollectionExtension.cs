using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;


namespace Restaurants.API.Restaurants.Application.Extensions
{
    // helper class to organize DI registrations
    public static class ServiceCollectionExtensions
    {
        // IServiceCollection => Dependency Injection container configuration
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

            services.AddAutoMapper(cfg => { }, typeof(ServiceCollectionExtensions).Assembly);

            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
        }
    }
}

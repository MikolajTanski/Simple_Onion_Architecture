using Microsoft.Extensions.DependencyInjection;
using Simple_Onion_Architecture.Application.Abstractions.Services;
using Simple_Onion_Architecture.Application.Services;

namespace Simple_Onion_Architecture.Application.Extensions;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        
        return services;
    }
}
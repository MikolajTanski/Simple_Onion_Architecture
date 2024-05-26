using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple_Onion_Architecture.Application.Abstractions.Repositories.Common;
using Simple_Onion_Architecture.Persistence.Context;

namespace Simple_Onion_Architecture.Persistence.Extensions;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicaitonDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        
        AddRepositoryToIoC(services, Assembly.GetExecutingAssembly());
        return services;
    }

    private static IServiceCollection AddRepositoryToIoC(IServiceCollection services, Assembly assembly)
    {
        var repositories = assembly.GetTypes()
            .Where(x => x.IsAssignableToGenericType(typeof(IRepository<>)) && !x.IsGenericType);
        foreach (var item in repositories)
        {
            var @interface = item.GetInterfaces().FirstOrDefault(x => !x.IsGenericType) ??
                             throw new ArgumentNullException();
            services.AddScoped(@interface, item);
        }

        return services;
    }


    private static bool IsAssignableToGenericType(this Type givenType, Type genericType)
    {
        return givenType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == genericType) ||
               (givenType.BaseType != null && ((givenType.BaseType.IsGenericType &&
                                                givenType.BaseType.GetGenericTypeDefinition() == genericType) ||
                                               givenType.BaseType.IsAssignableToGenericType(genericType)));
    }
}
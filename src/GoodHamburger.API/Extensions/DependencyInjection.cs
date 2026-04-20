using GoodHamburger.Application.Products.Mappings;
using GoodHamburger.Application.Queries;
using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Infrastructure.Seeds;
using System.Reflection;

namespace GoodHamburger.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetMenuQuery).Assembly);
        });

        return services;
    }

    public static IServiceCollection AddMapperServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ProductProfile).Assembly));
        return services;
    }


    public static IServiceCollection AddContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        return services;
    }
}
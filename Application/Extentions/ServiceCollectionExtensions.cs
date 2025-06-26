using Application.Interfaces;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extentions;

public static class ServiceCollectionExtensions
{

    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }


    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IGuestService, GuestService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

    }

}


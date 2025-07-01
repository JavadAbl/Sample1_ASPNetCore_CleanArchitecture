using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extentions;

public static class ServiceCollectionExtensions
{
    private static Assembly ApplicationAssembly = Assembly.GetExecutingAssembly();

    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
    }


    private static void AddServices(IServiceCollection services)
    {
        services.AddAutoMapper(ApplicationAssembly);
        services.AddValidatorsFromAssembly(ApplicationAssembly);
        services.AddMediatR(op => op.RegisterServicesFromAssembly(ApplicationAssembly));

    }
}

